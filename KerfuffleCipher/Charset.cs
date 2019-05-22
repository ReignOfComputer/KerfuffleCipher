using System;
using System.Linq;

namespace KerfuffleCipher
{
    public class Charset
    {
        public static char[,] smallAlphaChar = new char[2, 13]
        {
      {
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm'
      },
      {
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z'
      }
        };

        public static char[,] bigAlphaChar = new char[2, 13]
        {
      {
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M'
      },
      {
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z'
      }
        };

        public static char[] specialSymbol = new char[33]
        {
      '!',
      '@',
      '#',
      '$',
      '%',
      '^',
      '&',
      '*',
      '(',
      ')',
      '-',
      '=',
      '[',
      ']',
      '\\',
      ';',
      '\'',
      ',',
      '.',
      '/',
      '_',
      '+',
      '{',
      '}',
      '|',
      ':',
      '"',
      '<',
      '>',
      '?',
      ' ',
      '`',
      '~'
        };

        public static char[] number = new char[10]
        {
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      '0'
        };

        public static bool integrityCheck = false;

        public static char GetChar(int x, int y, int z)
        {
            if (z < 26)
                return smallAlphaChar[y - 1, x - 1];
            if (z < 51)
                return bigAlphaChar[y - 1, x - 1];
            if (z < 76)
                return specialSymbol[x - 1];
            if (z < 101)
            {
                if (y != 2)
                    integrityCheck = true;
                return number[x - 1];
            }
            integrityCheck = true;
            return 'a';
        }

        public static int[] GetMatrix(char ch)
        {
            int num1 = -1;
            int randomZcoordinate;
            int num2;
            if (number.Contains(ch))
            {
                randomZcoordinate = GenerateRandomZCoordinate(3);
                num2 = 2;
                for (int index = 0; index < number.Length; ++index)
                {
                    if (number[index].Equals(ch))
                    {
                        num1 = index + 1;
                        break;
                    }
                }
            }
            else
            {
                if (!specialSymbol.Contains(ch))
                    return Test(ch);
                randomZcoordinate = GenerateRandomZCoordinate(2);
                num2 = new Random().Next(0, 4);
                for (int index = 0; index < specialSymbol.Length; ++index)
                {
                    if (specialSymbol[index].Equals(ch))
                    {
                        num1 = index + 1;
                        break;
                    }
                }
            }
            return new int[3] { num1, num2, randomZcoordinate };
        }

        public static int GenerateRandomZCoordinate(int type)
        {
            int num = 0;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            switch (type)
            {
                case 0:
                    num += random.Next(0, 26);
                    break;
                case 1:
                    num += random.Next(25, 51);
                    break;
                case 2:
                    num += random.Next(51, 76);
                    break;
                case 3:
                    num += random.Next(76, 101);
                    break;
            }
            return num;
        }

        public static int GenerateNumber(int min, int max)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(min, max + 1);
        }

        public static int[] GetLowerCase(char ch)
        {
            int[] numArray = new int[3];
            bool flag = false;
            for (int index1 = 0; index1 < smallAlphaChar.Length / 13; ++index1)
            {
                for (int index2 = 0; index2 < smallAlphaChar.Length / 2; ++index2)
                {
                    if (smallAlphaChar[index1, index2].Equals(ch))
                    {
                        numArray[0] = index2 + 1;
                        numArray[1] = index1 + 1;
                        numArray[2] = GenerateRandomZCoordinate(0);
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }
            return numArray;
        }

        public static int[] GetUpperCase(char ch)
        {
            int[] numArray = new int[3];
            bool flag = false;
            for (int index1 = 0; index1 < bigAlphaChar.Length / 13; ++index1)
            {
                for (int index2 = 0; index2 < bigAlphaChar.Length / 2; ++index2)
                {
                    if (bigAlphaChar[index1, index2].Equals(ch))
                    {
                        numArray[0] = index2 + 1;
                        numArray[1] = index1 + 1;
                        numArray[2] = GenerateRandomZCoordinate(1);
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }
            return numArray;
        }

        public static int[] Test(char ch)
        {
            switch (ch)
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return GetUpperCase(ch);
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    return GetLowerCase(ch);
                default:
                    return new int[3] { -1, -1, -1 };
            }
        }
    }
}