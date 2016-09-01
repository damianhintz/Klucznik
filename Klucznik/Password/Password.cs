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
        /// Tablica na wartoœci liter alfabetu.
        /// Kolejne litery alfabetu otrzymuj¹ wartoœci odpowiednio 0, 1, 2,...
        /// </summary>
		private int[] values = new int[256];

        private PasswordCharset _charset;
        public PasswordCharset PassCharset
        {
            get { return _charset; }
        }

        /// <summary>
        /// Napis przechowuj¹cy litery alfabetu.
        /// </summary>
		private string charset;
		public string Charset
		{
			get { return charset; }
			set
			{
				/*
					Na podstawie alfabetu utwórz odwrotn¹ tablicê, do wyznaczania wartoœci liter alfabetu.
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
			Tablica do przechowywania reprezentacji numerycznej has³a.
		*/
		private readonly int[] digits = new int[256];
		public int this[int i]
		{
			get	{ return this.digits[i]; }
		}
		
		/*
			D³ugoœæ has³a w reprezentacji numerycznej.
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
                    throw new Exception("Has³o zawiera litery nie nale¿¹ce do alfabetu.");
                }
                digits[length - i - 1] = values[password[i]];
            }
			
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generujemy kolejne has³o
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
			
			//Je¿eli przechodzimy do hase³ o 1 d³u¿szych, to "zerujemy" nowe has³o.
			if(i >= length)
			{
				length++;
				digits[i] = 0;
			}
		}
		
		/*
			
		*/
        /// <summary>
        /// Generujemy has³o oddalone o "count" od bie¿¹cego. 
        /// Funkcja mo¿e wygenerowaæ has³o oddalone o mniejsz¹ odleg³oœæ.
        /// Funkcja zwróci rzeczywist¹ odleg³oœæ wygenerowanego has³a.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="real"></param>
        /// <returns></returns>
		public ulong Next(ulong count, bool real)
		{	
			/*
				Zamieñ "count" na odpowiedni¹ postaæ numeryczn¹.
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
					Mamy przepe³nienie. D³u¿sze liczby na pewno spowoduj¹ przepe³nienie i nie ma sensu dodawanie "count".
				*/
				overflow = true;
			}else
			{	
				/*
					Dodajemy "count". Przepe³nienie mo¿e nadal wyst¹piæ.
				*/
				int carry = 0;
				for(int i = 0;i < length;i++)
				{
					int t = countDigits[i] + digits[i] + carry;
					
					/*
						Skoro countDigits nie bêdzie nam ju¿ potrzebne przechowamy w nim star¹ wartoœæ has³a.
					*/
					countDigits[i] = digits[i];
					
					digits[i] = t % charset.Length;
					carry = t / charset.Length;
				}
				
				if(carry > 0)
				{
					/*
						Równie¿ mamy przepe³nienie. Trzeba odtworzyæ poprzednie has³o, aby póŸniej obliczyæ rzeczywist¹ odleg³oœæ.
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
					Je¿eli mamy przepe³nienie to mamy te¿ pewnoœæ, ¿e odejmuj¹c has³o graniczne od bie¿¹cego
					nie	wyst¹pi przepe³nienie typu liczby "count". Ustawiamy has³o na nastêpne za granicznym.
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
					Je¿eli chcemy, aby rzeczywiœcie funkcja generowa³a has³a oddalone o "count", to mo¿emy
					wywo³ywaæ j¹ rekurencyjnie a¿ dojdziemy do odpowiednio oddalonego has³a.
				*/
				newCount += this.Next(count - newCount, real);
			}
			return newCount;
		}
		
        /// <summary>
        /// Je¿eli chcemy obejœæ limit typu liczby "count" i wygenerowaæ has³o oddalone bardziej to mo¿emy
        /// podaæ drugi argument okreœlaj¹cy ile razy ma byæ count1*count2
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
        /// Porównaj reprezentacje numeryczne hase³.
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
        /// Oblicz hash has³a
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