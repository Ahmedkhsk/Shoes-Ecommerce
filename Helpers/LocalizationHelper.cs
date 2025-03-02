namespace Shoes_Ecommerce.Helpers
{
    public class LocalizationHelper
    {
        private static readonly Dictionary<string, Dictionary<string, string>> messages = new()
        {
            ["InvalidRequest"] = new()
            {
                ["en"] = "Invalid Request Data",
                ["ar"] = "البيانات المطلوبة غير صالحة"
            },
            ["UserNameAlreadyExists"] = new()
            {
                ["en"] = "UserName is already taken",
                ["ar"] = " الاسم مستخدم بالفعل"
            },
            ["EmailAlreadyExists"] = new()
            {
                ["en"] = "Email is already taken",
                ["ar"] = "البريد الإلكتروني مستخدم بالفعل"
            },
            ["RegistrationSuccess"] = new()
            {
                ["en"] = "User registered successfully.",
                ["ar"] = "تم تسجيل المستخدم بنجاح."
            },
            ["RegistrationFailed"] = new()
            {
                ["en"] = "User registration failed.",
                ["ar"] = "فشل تسجيل المستخدم."
            },
            ["VerificationSuccess"] = new()
            {
                ["en"] = "User Verification Successfully.",
                ["ar"] = "تم التحقق من المستخدم بنجاح."
            },
            ["VerificationFailed"] = new()
            {
                ["en"] = "User Verification Failed.",
                ["ar"] = "فشل التحقق من المستخدم."
            }
        };

        public static string GetLocalizedMessage(string key, string lan)
        {
            if (messages.ContainsKey(key) && messages[key].ContainsKey(lan))
            {
                return messages[key][lan];
            }
            return "An error occurred.";
        }
    }
}
