using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace tdsv121_dae_final.Utils
{
    public static class Validators
    {


        public static bool IsValidPhone(string phone)
        {

            int length = EnvironmentManager.GetPhoneNumberLength();

            return IsNumericOfExpectedLength(phone, length);
        }

        public static bool IsValidDocument(string document)
        {

            int length = EnvironmentManager.GetDocumentNumberLength();

            return IsNumericOfExpectedLength(document, length);
        }

        private static bool IsNumericOfExpectedLength(string value, int expectedLength)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value, $@"^\d{{{expectedLength}}}$");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress address = new MailAddress(email);

                return address.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
