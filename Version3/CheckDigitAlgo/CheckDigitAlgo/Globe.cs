using System;
using System.Globalization;
using System.Linq;

namespace CheckDigitAlgo
{
    public static class Globe
    {
        public static Boolean CheckDigitInnove(Int32 accountNo)
        {
            try
            {
                if (accountNo.ToString(CultureInfo.InvariantCulture).Length != 9)
                {
                    return false;
                }
                if (!(accountNo >= 100000000 && accountNo <= 999999999))
                {
                    return false;
                }

                var newAcctNo = (accountNo / 10);
                var chkDigitValue = (accountNo % 10);
                var chkDigit = 0;
                var wt = 1;
                while (!(newAcctNo <= 0))
                {
                    wt = wt * 2;
                    var rem = (newAcctNo % 10);
                    chkDigit = chkDigit + (rem * wt);
                    newAcctNo = (newAcctNo / 10);
                }

                chkDigit = chkDigit % 11;
                if (chkDigit > 9)
                {
                    chkDigit = 0;
                }
                return chkDigit == chkDigitValue;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static Boolean CheckDigitGlobeHandy(Int32 accountNo)
        {
            try
            {
                
                if (accountNo.ToString(CultureInfo.InvariantCulture).Length != 8)
                {
                    return false;
                }
                if (!(accountNo >= 10000000 && accountNo <= 99999999))
                {
                    return false;
                }
                var c = 0;
                var wt = 1;
                var newAccount = 10000000 + (accountNo / 10);

                while (newAccount > 0)
                {
                    wt = wt + 1;
                    var rem = newAccount % 10;
                    c = c + (rem * wt);
                    newAccount = newAccount / 10;
                }

                c = c % 11;
                c = 11 - c;

                return c == GetLastDigit(accountNo.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static Boolean CheckDigitVeco(String accountNo)
        {
            try
            {
                var tenDigitsAcct = accountNo.Substring(0, accountNo.Length - 1);

                var firstAlternateValue = GenerateAlternateValue(0, tenDigitsAcct);

                var a = SumAlternateDigit(Convert.ToInt32(firstAlternateValue));

                var secondAlternateValue = GenerateAlternateValue(1, tenDigitsAcct);

                var b = SumAlternateDigit(Convert.ToInt32(secondAlternateValue)) * 2;

                var c = a + b;

                var d = HighestCounter(secondAlternateValue);

                var e = d * 9;

                var f = c - e;

                var g = GetLastDigit(f.ToString(CultureInfo.InvariantCulture));

                var chckDigit = 0;

                if (g != 0)
                    chckDigit = 10 - g;

                return chckDigit == GetLastDigit(accountNo);
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static Boolean CheckAlgoGlobe10Digits(String accountNo)
        {
            try
            {
                if (accountNo.Length != 10)
                    return false;

                //var sum = SumOfAllTheProductOfEachDigits(Convert.ToInt32(accountNo));

                //var rem = sum%11;

                //var accountNumber = accountNo;

                //while (rem >= 10)
                //{
                //    accountNumber = Get9Digits(accountNumber);
                //    sum = SumOfAllTheProductOfEachDigits(Convert.ToInt32(accountNumber));
                //    rem = sum%11;
                //}

                //var newFaId = accountNumber + rem.ToString(CultureInfo.InvariantCulture);

                var checkSum = GetLastDigit(accountNo);

                var weight = SumOfAllTheProductOfEachDigits(Convert.ToInt32(Get9Digits(accountNo)));

                var newRem = weight%11;

                return newRem == checkSum && newRem < 10;
            }

            catch (Exception)
            {
                return false;
            }
            

        }

        public static Boolean CheckAsialinkFinaswide(String pn) //asialink and finaswide algo checking
        {
            try
            {
                var weight = new[] {2, 3, 4, 5, 6, 7};

                var sum = 0;
                var counter = 0;


                if (pn.StartsWith("522") || pn.StartsWith("523") ||
                        pn.StartsWith("53") || pn.StartsWith("527") ||
                        pn.StartsWith("528") || pn.StartsWith("541") || pn.StartsWith("542"))
                {
                    foreach (var value in Getpn(pn).ToCharArray().Reverse())
                    {
                        if (counter < 6)
                        {
                            sum = (int)(sum + char.GetNumericValue(value) * weight[counter]);
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                            sum = (int)(sum + char.GetNumericValue(value) * weight[counter]);
                            counter++;
                        }

                    }

                    var remainder = sum % 11;
                    var chckdigit = 0;

                    if (remainder == 0 || remainder == 1)
                    {
                        return chckdigit == GetLastDigit(pn);
                    }
                    else
                    {
                        chckdigit = 11 - remainder;
                        return chckdigit == GetLastDigit(pn);
                    }
                }
                else
                {
                        return false;                  
                }


            }
            catch (Exception)
            {
                return false;
            }

        }


        #region PrivateHelpers

        private static Int32 GetLastDigit(String value)
        {
            return
                Convert.ToInt32(
                    value.ToString(CultureInfo.InvariantCulture)
                        .Substring(value.ToString(CultureInfo.InvariantCulture).Length - 1));
        }

        private static Int32 HighestCounter(string value)
        {
            return value.Count(c => Char.GetNumericValue(c) > 4);
        }

        private static string GenerateAlternateValue(int startIndex, string value)
        {
            return new string(value.Where((ch, index) => index % 2 == startIndex).ToArray());
        }

        private static int SumAlternateDigit(Int32 value)
        {
            var sum = 0;
            while (value != 0)
            {
                sum += value % 10;
                value /= 10;
            }
            return sum;
        }

        private static string Get9Digits(String value)
        {
            return value.Substring(0, value.Length - 1);
        }

        private static String Getpn(string value) 
        {
            
                string newValue = null;
                if (value.StartsWith("52") || value.StartsWith("53"))
                {
                    newValue = value.Substring(2);
                   
                }
                else //if (value.StartsWith("541") || value.StartsWith("542") || value.StartsWith("543") || value.StartsWith("544"))
                {
                    newValue = value.Substring(3);
                    
                }
                return newValue.Substring(0, newValue.Length - 1);
        }
    
        private static int SumOfAllTheProductOfEachDigits(Int32 value)
        {
            var sum = 0;
            var multiPlier = 10;
            while (value != 0)
            {
                multiPlier -= 1;
                sum += ((value % 10) * multiPlier);
                value /= 10;
            }
            return sum;
        }
    } 
        #endregion
}
