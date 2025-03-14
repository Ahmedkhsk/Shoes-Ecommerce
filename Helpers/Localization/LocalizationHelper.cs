namespace Shoes_Ecommerce.Helpers.Localization
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
                ["en"] = "Verification Code is Wrong.",
                ["ar"] = "رمز التحقق خاطئ."
            },
            ["OTPSend"] = new()
            {
                ["en"] = "The OTP code has been sent.",
                ["ar"] = "تم إرسال رمز التحقق"
            },
            ["ChangePassSuccess"] = new()
            {
                ["en"] = "The password has been changed successfully.",
                ["ar"] = "تم تغيير كلمة المرور بنجاح."
            },
            ["PassFailed"] = new()
            {
                ["en"] = "The password Failed.",
                ["ar"] = "خطا في كلمه المرور."
            },
            ["UserNotFound"] = new()
            {
                ["en"] = "User not found.",
                ["ar"] = "لم يتم العثور على المستخدم."
            },
            ["PassMismatch"] = new()
            {
                ["en"] = "New password and confirm password do not match.",
                ["ar"] = "كلمة المرور الجديدة وتأكيد كلمة المرور غير متطابقين."
            },
            ["IncorrectOldPass"] = new()
            {
                ["en"] = "Old password is Incorrect.",
                ["ar"] = "كلمة السر القديمة غير صحيحة."
            },
            ["LoginSuccess"] = new()
            {
                ["en"] = "User logged in successfully.",
                ["ar"] = "تم تسجيل دخول المستخدم بنجاح."
            },
            ["LoginFailed"] = new()
            {
                ["en"] = "Email or Password Invalid.",
                ["ar"] = "الايميل او الباسورد خطا."
            },
            ["CategoryAddedSuccess"] = new()
            {
                ["en"] = "Category added successfully.",
                ["ar"] = "تم إضافة الفئة بنجاح."
            },
            ["NoCategoriesFound"] = new()
            {
                ["en"] = "No categories found.",
                ["ar"] = "لم يتم العثور على أي فئات."
            },
            ["CategoriesRetrieved"] = new()
            {
                ["en"] = "Categories retrieved successfully.",
                ["ar"] = "تم استرجاع الفئات بنجاح."
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
