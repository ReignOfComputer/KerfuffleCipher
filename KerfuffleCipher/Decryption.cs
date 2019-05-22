using System;
using System.Collections.Generic;

namespace KerfuffleCipher
{
    public class Decryption
    {
        public static bool integrityViolated;

        public static int[,,] DisplayArrayFromString(string text)
        {
            string[] strArray1 = text.Remove(text.Length - 1, 1).Remove(0, 1).Split(new string[1]
            {
        "]["
            }, StringSplitOptions.RemoveEmptyEntries);
            List<string> stringList = new List<string>();
            int length = 0;
            for (int index = 0; index < strArray1.Length; ++index)
            {
                if (index * 2 < strArray1.Length && index * 2 + 1 < strArray1.Length)
                {
                    string str = strArray1[index * 2] + ", " + strArray1[index * 2 + 1];
                    stringList.Add(str);
                    ++length;
                }
            }
            string[] array1 = stringList.ToArray();
            List<int[]> numArrayList = new List<int[]>();
            for (int index1 = 0; index1 < array1.Length; ++index1)
            {
                string[] strArray2 = array1[index1].Split(new string[1]
                {
          ", "
                }, StringSplitOptions.RemoveEmptyEntries);
                int[] numArray = new int[strArray2.Length];
                for (int index2 = 0; index2 < strArray2.Length; ++index2)
                    numArray[index2] = int.Parse(strArray2[index2]);
                numArrayList.Add(numArray);
            }
            int[][] array2 = numArrayList.ToArray();
            int[,,] numArray1 = new int[length, 2, 3];
            for (int index1 = 0; index1 < numArray1.Length / 6; ++index1)
            {
                for (int index2 = 0; index2 < 2; ++index2)
                {
                    if (array2[index1][0] - array2[index1][3] < 0)
                    {
                        if (index2 == 0)
                        {
                            numArray1[index1, index2, 0] = array2[index1][3];
                            numArray1[index1, index2, 1] = array2[index1][4];
                            numArray1[index1, index2, 2] = array2[index1][5];
                        }
                        else
                        {
                            numArray1[index1, index2, 0] = array2[index1][0];
                            numArray1[index1, index2, 1] = array2[index1][1];
                            numArray1[index1, index2, 2] = array2[index1][2];
                        }
                    }
                    else if (index2 == 0)
                    {
                        numArray1[index1, index2, 0] = array2[index1][0];
                        numArray1[index1, index2, 1] = array2[index1][1];
                        numArray1[index1, index2, 2] = array2[index1][2];
                    }
                    else
                    {
                        numArray1[index1, index2, 0] = array2[index1][3];
                        numArray1[index1, index2, 1] = array2[index1][4];
                        numArray1[index1, index2, 2] = array2[index1][5];
                    }
                }
            }
            return numArray1;
        }

        public static int[,] Decrypt(int[,,] array)
        {
            int[,] numArray = new int[array.Length / 6, 3];
            for (int index1 = 0; index1 < array.Length / 6; ++index1)
            {
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                for (int index2 = 0; index2 < 2; ++index2)
                {
                    bool flag = false;
                    for (int index3 = 0; index3 < 3; ++index3)
                    {
                        if (index2 == 0)
                        {
                            switch (index3)
                            {
                                case 0:
                                    num1 = array[index1, index2, index3];
                                    continue;
                                case 1:
                                    num2 = array[index1, index2, index3];
                                    continue;
                                case 2:
                                    num3 = array[index1, index2, index3];
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
                                    num4 = array[index1, index2, index3];
                                    break;
                                case 1:
                                    num5 = array[index1, index2, index3];
                                    break;
                                case 2:
                                    num6 = array[index1, index2, index3];
                                    break;
                            }
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        if (num1 - num4 < 0 || num2 - num5 < 0 || num3 - num6 < 0)
                        {
                            numArray[index1, 0] = num4 - num1;
                            numArray[index1, 1] = num5 - num2;
                            numArray[index1, 2] = num6 - num3;
                        }
                        else
                        {
                            numArray[index1, 0] = num1 - num4;
                            numArray[index1, 1] = num2 - num5;
                            numArray[index1, 2] = num3 - num6;
                        }
                        if ((index1 + 1) % 7 != 0 && Charset.GetChar(numArray[index1, 0], numArray[index1, 1], numArray[index1, 2]) != num6 - num5)
                            integrityViolated = true;
                        num4 = 0;
                        num5 = 0;
                        num6 = 0;
                        num1 = 0;
                        num2 = 0;
                        num3 = 0;
                    }
                }
            }
            return numArray;
        }

        public static string GetMessage(int[,] array)
        {
            string str = "";
            for (int index = 0; index < array.Length / 3; ++index)
            {
                if ((index + 1) % 7 != 0)
                {
                    char ch = Charset.GetChar(array[index, 0], array[index, 1], array[index, 2]);
                    str += ch;
                }
            }
            if (Charset.integrityCheck || integrityViolated)
            {
                str = "Data appears to be malformed or tampered.";
                Charset.integrityCheck = false;
                integrityViolated = false;
            }
            return str;
        }

        public static bool CheckMatrixValidity(int[,,] matrix)
        {
            bool flag = true;
            for (int index1 = 0; index1 < matrix.Length / 6; ++index1)
            {
                for (int index2 = 0; index2 < 2; ++index2)
                {
                    for (int index3 = 0; index3 < 2; ++index3)
                    {
                        if (matrix[index1, index2, index3] == -1)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                        break;
                }
                if (!flag)
                    break;
            }
            return flag;
        }
    }
}