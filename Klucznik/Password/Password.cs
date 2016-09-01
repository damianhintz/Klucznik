using System;
using System.Text;
using System.Security.Cryptography;

namespace Klucznik.Password
{
    [Serializable]
    /// <summary>
    /// Password
    /// </summary>
	public class Password : IComparable<Password>
    {
        #region Fields

        /// <summary>
        /// Rodzaj algorytmu hashowania
        /// </summary>
        private IHashAlgorithm _iha;
        public IHashAlgorithm HashAlgorithm
        {
            get { return this._iha; }
        }

        /// <summary>
        /// Tablica na warto�ci liter alfabetu.
        /// Kolejne litery alfabetu otrzymuj� warto�ci odpowiednio 0, 1, 2,...
        /// </summary>
		private int[] values = new int[256];

        private PasswordCharset _charset;
        public PasswordCharset PassCharset
        {
            get { return _charset; }
        }

        /// <summary>
        /// Napis przechowuj�cy litery alfabetu.
        /// </summary>
		private string charset;
		public string Charset
		{
			get { return charset; }
			set
			{
				/*
					Na podstawie alfabetu utw�rz odwrotn� tablic�, do wyznaczania warto�ci liter alfabetu.
				*/
				charset = value;
				for(int i = 0;i < 256;i++)
				{
					values[i] = -1;
				}
				for(int i = 0;i < charset.Length;i++)
				{
					values[charset[i]] = i;
				}
			}
		}
		
		private string password;
		private byte[] passbyte = new byte[256];
		
		/*
			Tablica do przechowywania reprezentacji numerycznej has�a.
		*/
		private readonly int[] digits = new int[256];
		public int this[int i]
		{
			get	{ return this.digits[i]; }
		}
		
		/*
			D�ugo�� has�a w reprezentacji numerycznej.
		*/
		private int length = 0;
		public int Length
		{
			get { return this.length; }
        }

        #endregion

        #region Constructors

        public Password(string password, PasswordCharset charset, IHashAlgorithm iha)
        {

            Charset = charset.Charset;
            this.charset = charset.Charset;

            _charset = charset;
            _iha = iha;
            
            this.password = password;
            this.length = password.Length;
            for (int i = 0; i < length; i++)
            {
                if (values[password[i]] == -1)
                {
                    throw new Exception("Has�o zawiera litery nie nale��ce do alfabetu.");
                }
                digits[length - i - 1] = values[password[i]];
            }
			
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generujemy kolejne has�o
        /// </summary>
		public void Next()
		{
			int i = 0;
			while(true)
			{
				if(digits[i] + 1 < charset.Length)
				{
					digits[i]++;
					break;
				}
				digits[i++] = 0;
			}
			
			//Je�eli przechodzimy do hase� o 1 d�u�szych, to "zerujemy" nowe has�o.
			if(i >= length)
			{
				length++;
				digits[i] = 0;
			}
		}
		
		/*
			
		*/
        /// <summary>
        /// Generujemy has�o oddalone o "count" od bie��cego. 
        /// Funkcja mo�e wygenerowa� has�o oddalone o mniejsz� odleg�o��.
        /// Funkcja zwr�ci rzeczywist� odleg�o�� wygenerowanego has�a.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="real"></param>
        /// <returns></returns>
		public ulong Next(ulong count, bool real)
		{	
			/*
				Zamie� "count" na odpowiedni� posta� numeryczn�.
			*/
			ulong newCount = count;
			int[] countDigits = new int[256];
			int countLength = 0;
			do
			{
				countDigits[countLength++] = (int)(count % (ulong)charset.Length);
			}while((count /= (ulong)charset.Length) > 0);
			count = newCount;
			
			bool overflow = false;
			if(countLength > length)
			{
				/*
					Mamy przepe�nienie. D�u�sze liczby na pewno spowoduj� przepe�nienie i nie ma sensu dodawanie "count".
				*/
				overflow = true;
			}else
			{	
				/*
					Dodajemy "count". Przepe�nienie mo�e nadal wyst�pi�.
				*/
				int carry = 0;
				for(int i = 0;i < length;i++)
				{
					int t = countDigits[i] + digits[i] + carry;
					
					/*
						Skoro countDigits nie b�dzie nam ju� potrzebne przechowamy w nim star� warto�� has�a.
					*/
					countDigits[i] = digits[i];
					
					digits[i] = t % charset.Length;
					carry = t / charset.Length;
				}
				
				if(carry > 0)
				{
					/*
						R�wnie� mamy przepe�nienie. Trzeba odtworzy� poprzednie has�o, aby p�niej obliczy� rzeczywist� odleg�o��.
					*/
					overflow = true;
					for(int i = 0;i < length;i++)
					{
						digits[i] = countDigits[i];
					}
				}
			}
			if(overflow)
			{
				/*
					Je�eli mamy przepe�nienie to mamy te� pewno��, �e odejmuj�c has�o graniczne od bie��cego
					nie	wyst�pi przepe�nienie typu liczby "count". Ustawiamy has�o na nast�pne za granicznym.
				*/
				newCount = 0;
				int maxValue = values[charset[charset.Length-1]];
				for(int i = length - 1;i >= 0;i--)
				{
					newCount = (ulong)charset.Length * newCount + (ulong)(maxValue - digits[i]);
				}
				
				length++;
				for(int i = 0;i < length;i++)
				{
					digits[i] = 0;
				}
				newCount++;
			}
			if(newCount < count && real)
			{
				/*
					Je�eli chcemy, aby rzeczywi�cie funkcja generowa�a has�a oddalone o "count", to mo�emy
					wywo�ywa� j� rekurencyjnie a� dojdziemy do odpowiednio oddalonego has�a.
				*/
				newCount += this.Next(count - newCount, real);
			}
			return newCount;
		}
		
        /// <summary>
        /// Je�eli chcemy obej�� limit typu liczby "count" i wygenerowa� has�o oddalone bardziej to mo�emy
        /// poda� drugi argument okre�laj�cy ile razy ma by� count1*count2
        /// </summary>
        /// <param name="count1"></param>
        /// <param name="count2"></param>
        /// <param name="real"></param>
		public void Next(ulong count1, int count2, bool real)
		{
			for(int i = 0;i < count2;i++)
			{
				this.Next(count1, real);
			}
		}
		
		public override string ToString()
		{
			StringBuilder password = new StringBuilder();
			for(int i = length - 1;i >= 0;--i)
			{
				if(digits[i] >= 0)
				{
					password.Append(charset[digits[i]]);
				}
			}
			return password.ToString();
		}
		
		/*public override bool Equals(Object obj)
		{
			return false;
		}*/
		
		public static Password operator ++(Password password)
		{
			password.Next();
			return password;
		}
		
		public static Password operator +(Password password, ulong passwordCount)
		{
			password.Next(passwordCount, true);
			return password;
		}
		
		public static bool operator <=(Password p1, Password p2)
		{
			return p1.CompareTo(p2) < 1;
		}
		
		public static bool operator >=(Password p1, Password p2)
		{
			return p1.CompareTo(p2) > -1;
		}

		public static bool operator <(Password p1, Password p2)
		{
			return p1.CompareTo(p2) < 0;
		}
		
		public static bool operator >(Password p1, Password p2)
		{
			return p1.CompareTo(p2) > 0;
		}
		
		public bool Equals(Password password)
		{
			return this.CompareTo(password) == 0;
		}
		
        /// <summary>
        /// Por�wnaj reprezentacje numeryczne hase�.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
		public int CompareTo(Password password)
		{
			if(this.length > password.Length)
			{
				return 1;
			}else
			if(this.length < password.Length)
			{
				return -1;
			}else
			{
				for(int i = this.length - 1;i >= 0;i--)
				{
					if(this.digits[i] > password[i])
					{
						return 1;
					}else
					if(this.digits[i] < password[i])
					{
						return -1;
					}
				}
			}
			return 0;
		}
		
        /// <summary>
        /// Oblicz hash has�a
        /// </summary>
        /// <returns></returns>
		public string Hash()
		{
            for (int i = 0; i < length; i++)
            {
                passbyte[i] = (byte)charset[digits[i]];
            }
			return _iha.Hash(passbyte, 0, length);
        }

        #endregion
    }
    

}