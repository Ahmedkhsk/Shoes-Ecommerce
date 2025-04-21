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
            ["CategoryUpdatedSuccess"] = new()
            {
                ["en"] = "Category Updated Successfully.",
                ["ar"] = "تم إضافة الفئة بنجاح."
            },
            ["CategoryDeletedSuccess"] = new()
            {
                ["en"] = "Category Deleted Successfully.",
                ["ar"] = "تم إضافة الفئة بنجاح."
            },
            ["NoCategoriesFound"] = new()
            {
                ["en"] = "No categories found.",
                ["ar"] = "لم يتم العثور على أي فئات."
            },
            ["CategoryNotFound"] = new()
            {
                ["en"] = "Category not Found.",
                ["ar"] = "لم يتم العثور على أي فئات."
            },
            ["CategoriesRetrieved"] = new()
            {
                ["en"] = "Categories retrieved successfully.",
                ["ar"] = "تم استرجاع الفئات بنجاح."
            },
            ["ProductAddedSuccess"] = new()
            {
                ["en"] = "Product added successfully.",
                ["ar"] = "تم إضافة المنتج بنجاح."
            },
            ["ProductUpdatedSuccess"] = new()
            {
                ["en"] = "Product updated successfully.",
                ["ar"] = "تم تحديث المنتج بنجاح."
            },
            ["ProductDeletedSuccess"] = new()
            {
                ["en"] = "Product deleted successfully.",
                ["ar"] = "تم حذف المنتج بنجاح."
            },
            ["NoProductsFound"] = new()
            {
                ["en"] = "No Products found.",
                ["ar"] = "لم يتم العثور على أي منتجات."
            },
            ["ProductNotFound"] = new()
            {
                ["en"] = "Product Not Found.",
                ["ar"] = "لم يتم العثور على المنتج."
            },
            ["ProductsRetrieved"] = new()
            {
                ["en"] = "Products retrieved successfully.",
                ["ar"] = "تم استرجاع المنتجات بنجاح."
            },
            ["ImagesUploadedSuccessfully"] = new() 
            {
                ["en"] = "Images uploaded successfully.",
                ["ar"] = "تم رفع الصور بنجاح."
            },
            ["ProductAddedToFavorites"] = new()
            {
                ["en"] = "Product added to favorites successfully.",
                ["ar"] = "تمت إضافة المنتج إلى المفضلة بنجاح."
            },
            ["ProductRemovedFromFavorites"] = new()
            {
                ["en"] = "Product removed from favorites successfully.",
                ["ar"] = "تمت إزالة المنتج من المفضلة بنجاح."
            },
            ["NoFavoritesFound"] = new()
            {
                ["en"] = "No favorites found.",
                ["ar"] = "لم يتم العثور على المفضلات."
            },
            ["FavoritesRetrieved"] = new()
            {
                ["en"] = "Favorites retrieved successfully.",
                ["ar"] = "تم استرجاع المفضلات بنجاح."
            },
            ["ProductUpdatedInFavorites"] = new()
            {
                ["en"] = "Favorite Updated successfully.",
                ["ar"] = "تم تحديث المفضله بنجاح."
            },
            ["ProductAddedToCart"] = new()
            {
                ["en"] = "Product added to cart successfully.",
                ["ar"] = "تمت إضافة المنتج إلى السلة بنجاح."
            },
            ["ProductRemovedFromCart"] = new()
            {
                ["en"] = "Product removed from cart successfully.",
                ["ar"] = "تمت إزالة المنتج من السلة بنجاح."
            },
            ["NoCartItemsFound"] = new()
            {
                ["en"] = "No cart items found.",
                ["ar"] = "لم يتم العثور على عناصر السلة."
            },
            ["CartItemsRetrieved"] = new()
            {
                ["en"] = "Cart items retrieved successfully.",
                ["ar"] = "تم استرجاع عناصر السلة بنجاح."
            },
            ["CartItemsCleared"] = new()
            {
                ["en"] = "Cart items cleared successfully.",
                ["ar"] = "تم مسح عناصر السلة بنجاح."
            },
            ["OrderPlacedSuccessfully"] = new()
            {
                ["en"] = "Order placed successfully.",
                ["ar"] = "تم تقديم الطلب بنجاح."
            },
            ["NoOrdersFound"] = new()
            {
                ["en"] = "No orders found.",
                ["ar"] = "لم يتم العثور على أي"
            },
            ["ImageUpload"] = new()
            {
                ["en"] = "An error occurred while uploading the image.",
                ["ar"] = "حدث خطأ أثناء رفع الصورة."
            },
            ["UpdateFailed"] = new()
            {
                ["en"] = "Failed to update the profile.",
                ["ar"] = "فشل في تحديث الملف الشخصي."
            },

            ["ProfileUpdated"] = new()
            {
                ["en"] = "Profile updated successfully.",
                ["ar"] = "تم تحديث الملف الشخصي بنجاح."
            }
            ,
            ["UserRetrived"] = new()
            {
                ["en"] = "User retrived successfully.",
                ["ar"] = "تم استرجاع المستخدم بنجاح."
            },

            ["UserNotFound"] = new()
            {
                ["en"] = "User not found.",
                ["ar"] = "لم يتم العثور على المستخدم."
            },
            ["UserDeleted"] = new()
            {
                ["en"] = "User Deleted.",
                ["ar"] = "تم حذف المستخدم."
            },
            ["InvalidQuantity"] = new()
            {
                ["en"] = "Invalid quantity.",
                ["ar"] = "كمية غير صالحة."
            },
            ["ProductQuantityUpdated"] = new()
            {
                ["en"] = "Product quantity updated successfully.",
                ["ar"] = "تم تحديث كمية المنتج بنجاح."
            },
            ["ProductNotFoundInCart"] = new()
            {
                ["en"] = "Product not found in cart.",
                ["ar"] = "لم يتم العثور على المنتج في السلة."
            },
            ["ProductQuantityUpdatedInCart"] = new()
            {
                ["en"] = "Product quantity updated in cart successfully.",
                ["ar"] = "تم تحديث كمية المنتج في السلة بنجاح."
            },
            ["OrderNotFound"] = new()
            {
                ["en"] = "Order not found.",
                ["ar"] = "لم يتم العثور على الطلب."
            },
            ["OrderStatusUpdated"] = new()
            {
                ["en"] = "Order status updated successfully.",
                ["ar"] = "تم تحديث حالة الطلب بنجاح."
            },
            ["OrderDeleted"] = new()
            {
                ["en"] = "Order deleted successfully.",
                ["ar"] = "تم حذف الطلب بنجاح."
            },
            ["OrderNotFoundInCart"] = new()
            {
                ["en"] = "Order not found in cart.",
                ["ar"] = "لم يتم العثور على الطلب في السلة."
            },
            ["OrderStatusUpdatedInCart"] = new()
            {
                ["en"] = "Order status updated in cart successfully.",
                ["ar"] = "تم تحديث حالة الطلب في السلة بنجاح."
            },
            ["ProductNotFoundInFavorites"] = new()
            {
                ["en"] = "Product not found in favorites.",
                ["ar"] = "لم يتم العثور على المنتج في المفضلة."
            },
            ["ProductQuantityUpdatedInFavorites"] = new()
            {
                ["en"] = "Product quantity updated in favorites successfully.",
                ["ar"] = "تم تحديث كمية المنتج في المفضلة بنجاح."
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
