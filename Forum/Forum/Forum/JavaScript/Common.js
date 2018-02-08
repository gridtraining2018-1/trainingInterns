function DateFormat(now) {
    hours = now.getHours();
    minutes = now.getMinutes();
    seconds = now.getSeconds();
    day = now.getDate();
    month = now.getMonth() + 1;
    year = now.getFullYear();
    timestr = "" + ((month < 10) ? "0" : "") + month;
    timestr += ((Date < 10) ? "-0" : "-") + day;
    timestr += "-" + year + " ";
    timestr += ((hours < 10) ? "0" : "") + hours;
    timestr += ((minutes < 10) ? ":0" : ":") + minutes;
    timestr += ((seconds < 10) ? ":0" : ":") + seconds;
    return timestr;
}