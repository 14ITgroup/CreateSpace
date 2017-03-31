/**
 * Created by 17922 on 2017/3/25.
 */
/*
 * input参数收集
 */
function getinfo() {
    var name = $(".mt-form-body>.mt:nth-child(1)>div+div>input").val();
    var tel = $(".mt-form-body>.mt:nth-child(2)>div+div>input").val();
    var email = $(".mt-form-body>.mt:nth-child(3)>div+div>input").val();
    var sponsor = $(".mt-form-body>.mt:nth-child(4)>div+div>input").val();
    var theme = $(".mt-form-body>.mt:nth-child(5)>div+div>input").val();
    var content = $(".mt-form-body>.mt:nth-child(6)>div+div>textarea").val();
    if(name == "" || tel == "" || email == "" || sponsor == ""|| theme == ""||content == ""){
        alert("请填写完整信息帮助您核实");
    }
    else if(!(/^1[1|3|4|5|7|8][0-9]\d{4,8}$/.test(tel))){
        alert("不是完整的11位手机号或者正确的手机号前七位");
        $(".mt-form-body>.mt:nth-child(2)>div+div>input").focus();
        return false;
    }
    else if (!(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/.test(email))){
        alert("请输入正确的邮箱");
        $(".mt-form-body>.mt:nth-child(3)>div+div>input").focus();
        return false;
    }
    else {
        alert("预约成功");
    }


}
