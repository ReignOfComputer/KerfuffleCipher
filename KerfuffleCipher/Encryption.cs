using System;
using System.Collections.Generic;
using System.Linq;

namespace KerfuffleCipher
{
    public class Encryption
    {
        public static int[,,] Encrypt(string text)
        {
            char[] charArray = text.ToCharArray();
            int[,,] numArray1 = new int[charArray.Length, 2, 3];
            for (int index1 = 0; index1 < numArray1.Length / 6; ++index1)
            {
                byte num = (byte)charArray[index1];
                int[] matrix = Charset.GetMatrix(charArray[index1]);
                int[] randomMatrix1 = GenerateRandomMatrix();
                randomMatrix1[2] = randomMatrix1[1] + (int)num;
                for (int index2 = 0; index2 < 2; ++index2)
                {
                    for (int index3 = 0; index3 < 3; ++index3)
                    {
                        if ((index1 + 1) % 7 != 0)
                        {
                            if (matrix[2] == 2)
                            {
                                if (index2 == 0)
                                {
                                    switch (index3)
                                    {
                                        case 0:
                                            numArray1[index1, index2, index3] = randomMatrix1[index3];
                                            continue;
                                        case 1:
                                            numArray1[index1, index2, index3] = randomMatrix1[index3];
                                            continue;
                                        case 2:
                                            numArray1[index1, index2, index3] = randomMatrix1[index3];
                                            continue;
                                        default:
                                            continue;
                                    }
                                }
                                else
                                {
                                    int[] numArray2 = AddMethod(matrix, randomMatrix1);
                                    switch (index3)
                                    {
                                        case 0:
                                            numArray1[index1, index2, index3] = numArray2[index3];
                                            continue;
                                        case 1:
                                            numArray1[index1, index2, index3] = numArray2[index3];
                                            continue;
                                        case 2:
                                            numArray1[index1, index2, index3] = numArray2[index3];
                                            continue;
                                        default:
                                            continue;
                                    }
                                }
                            }
                            else if (index2 == 0)
                            {
                                int[] numArray2 = AddMethod(matrix, randomMatrix1);
                                switch (index3)
                                {
                                    case 0:
                                        numArray1[index1, index2, index3] = numArray2[index3];
                                        continue;
                                    case 1:
                                        numArray1[index1, index2, index3] = numArray2[index3];
                                        continue;
                                    case 2:
                                        numArray1[index1, index2, index3] = numArray2[index3];
                                        continue;
                                    default:
                                        continue;
                                }
                            }
                            else
                            {
                                switch (index3)
                                {
                                    case 0:
                                        numArray1[index1, index2, index3] = randomMatrix1[index3];
                                        continue;
                                    case 1:
                                        numArray1[index1, index2, index3] = randomMatrix1[index3];
                                        continue;
                                    case 2:
                                        numArray1[index1, index2, index3] = randomMatrix1[index3];
                                        continue;
                                    default:
                                        continue;
                                }
                            }
                        }
                        else if (index2 == 0)
                        {
                            int[] randomMatrix2 = GenerateRandomMatrix();
                            numArray1[index1, index2, 0] = randomMatrix2[0];
                            numArray1[index1, index2, 1] = randomMatrix2[1];
                            numArray1[index1, index2, 2] = randomMatrix2[2];
                        }
                        else
                        {
                            int[] randomMatrix2 = GenerateRandomMatrix();
                            numArray1[index1, index2, 0] = randomMatrix2[0];
                            numArray1[index1, index2, 1] = randomMatrix2[1];
                            numArray1[index1, index2, 2] = randomMatrix2[2];
                        }
                    }
                }
            }
            return numArray1;
        }

        public static int[] GenerateRandomMatrix()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return new int[3]
            {
        random.Next(0, 101),
        random.Next(0, 101),
        random.Next(0, 101)
            };
        }

        public static string InsertGarbledText(string text)
        {
            List<char> charList = new List<char>();
            char[] array = text.ToArray();
            for (int index = 0; index < array.Length; ++index)
            {
                charList.Add(array[index]);
                if ((index + 1) % 6 == 0)
                    charList.Add('-');
            }
            return string.Join("", charList.ToArray());
        }

        public static int[] AddMethod(int[] firstArray, int[] secondArray)
        {
            int[] numArray = new int[3];
            for (int index = 0; index < numArray.Length; ++index)
                numArray[index] = firstArray[index] + secondArray[index];
            return numArray;
        }

        public static string DisplayMatrix(int[,,] array)
        {
            string str1 = "";
            for (int index1 = 0; index1 < array.GetLength(0); ++index1)
            {
                for (int index2 = 0; index2 < array.GetLength(1); ++index2)
                {
                    string str2 = str1 + '[';
                    for (int index3 = 0; index3 < array.GetLength(2); ++index3)
                    {
                        str2 += array[index1, index2, index3];
                        if (index3 != 2)
                            str2 += ", ";
                    }
                    str1 = str2 + ']';
                }
            }
            if (AddMessage(Charset.GenerateNumber(0, 100)))
                str1 += string.Format("[{0}, {1}, {2}]", Charset.GenerateNumber(0, 100), Charset.GenerateNumber(0, 100), Charset.GenerateNumber(0, 100));
            return str1;
        }

        public static bool AddMessage(int num)
        {
            return num < 51;
        }
    }
}