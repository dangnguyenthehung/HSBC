using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSCB.Constants
{
    public struct MessageConstants
    {
        public static string ContactSubmitFail = "Gửi thông tin liên hệ thất bại, vui lòng thử lại sau!";

        public static string NotFound = "Rất tiếc! Chúng tôi không tìm thấy trang bạn yêu cầu!";

        public static string RegisterSuccess = "Đăng kí thành công!";

        public static string InsertSuccess = "Thêm mới thành công!";

        public static string Unauthorize = "Bạn không có quyền thực hiện chức năng này!";

        public static string HaveChildCategories = "Bạn không thể xóa danh mục này vì vẫn còn những danh mục con liên quan!";
    }
}