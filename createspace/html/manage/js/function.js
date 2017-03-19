/**
 * Created by Zzzzzzzjk on 2016/10/7.
 */
/*
 * 是否预约检测
 */
var isclick = 0;

document.onclick = function(){
    isclick = 0;
};
$(".timepicker-small .timepicker-small-timeslot-list input[type=radio]").click(function(e){
    isclick = 1;
    var ev = e || window.event;
    if(ev.stopPropagation){
        ev.stopPropagation();
    }
    else if(window.event){
        window.event.cancelBubble = true;//兼容IE
    }
})
$(".timepicker-cell").click(function(e){
    isclick = 1;
    var ev = e || window.event;
    if(ev.stopPropagation){
        ev.stopPropagation();
    }
    else if(window.event){
        window.event.cancelBubble = true;//兼容IE
    }
})
$("#timepicker-submit").click(function(e){
    var ev = e || window.event;
    if(ev.stopPropagation){
        ev.stopPropagation();
    }
    else if(window.event){
        window.event.cancelBubble = true;//兼容IE
    }
})
var myWindow;
function submitClick() {
    if (isclick == 1) {
        window.open('input.html');
    }
    else {
        alert("请选择要预约的时间！");
    }
}
/*
 * 动态时间显示
 */
function timeChange() {
    switch (time) {
        case 1:
            time = "一";
            break;
        case 2:
            time = "二";
            break;
        case 3:
            time = "三";
            break;
        case 4:
            time = "四";
            break;
        case 5:
            time = "五";
            break;
        case 6:
            time = "六";
            break;
        case 7:
        case 0:
            time = "日";
            break;
    }
}
function dateChange() {
    if (date <10 ){
        date = "0"+date;
    }

}
var myDate = new Date();
var year = myDate.getFullYear();
var month = myDate.getMonth()+1;
var date = myDate.getDate();
var time = myDate.getDay();
for(var i=0; i<7; i++){
    date = date + i;
    time = time + i;
    if(time > 7){
        time = time - 7;
    }
    timeChange();
    dateChange();
    document.getElementsByTagName('th')[i].innerHTML = month + "月" + date + "日 " + "星期" + time;
    document.getElementsByClassName('date-text')[i].innerHTML = "星期" + time ;
    document.getElementsByClassName('date-number')[i].innerHTML = date + "日";
    date = myDate.getDate();
    time = myDate.getDay();
}

var datelate = date + 6;
document.getElementsByTagName('h4')[0].innerHTML =  month + " 月 " + date + " 日 " +" - " + month + " 月 " + datelate + " 日 ";

date = myDate.getDate();
time = myDate.getDay();

for(var j=0; j<7; j++){
    date = date + j;
    time = time + j;
    if(time > 7){
        time = time - 7;
    }
    timeChange();
    dateChange();
    var setTime =  date + "日 " + "星期" + time + ".";
    for(var l = 0;l < 3;l++) {
        document.getElementsByTagName('p')[j*3+l].innerHTML = setTime;
    }
    date = myDate.getDate();
    time = myDate.getDay();
}


/*
 * 页面且切换
 */
function theNext() {
    $(".paddlenav-arrow-left").css("display","table-cell");
    $(".paddlenav-arrow-right").css("display","none");
    $(".timepicker-current-medium").css("display","none");
    $(".timepicker-next-medium").css("display","table-cell");
    $(".timepicker-timeslots.timepicker-timeslots-medium").css("border-spacing","4rem 1.33rem");
}
function theLast() {
    $(".paddlenav-arrow-left").css("display","none");
    $(".paddlenav-arrow-right").css("display","table-cell");
    $(".timepicker-current-medium").css("display","table-cell");
    $(".timepicker-next-medium").css("display","none");
    $(".timepicker-timeslots.timepicker-timeslots-medium").css("border-spacing","2rem 1.33rem");
}
/*
 * 窗口大小改变强制刷新
 */
var width_one = 0;
var width_two = 0;
window.onresize = function(){
    var winWidth = document.body.clientWidth;
    width_one = winWidth;
    if(width_two < 1068 && width_one > 1068 && width_one !=0 && width_two != 0) {
        window.location.reload();
    }
    width_two = width_one;
};
/*
 * 页面传值获取
 */
