/*global jQuery:false */
jQuery(document).ready(function($) {
    function validateEmail($email) {
        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        return emailReg.test($email);
    }
	//Contact
	$("#btnReceiveNews").click(function() {
        var emailaddress = $("#email").val();
        if (emailaddress !== "") {
            if (!validateEmail(emailaddress)) {
                /* if false*/
                $("#emailError").html("Không đúng định dạng email!");
            } else {
                $("#frmReceiveNews form").submit();
                alert("Đăng kí thành công!");
            }    
        } else {
            $("#emailError").html("Vui lòng nhập email");
        } 
	});

});