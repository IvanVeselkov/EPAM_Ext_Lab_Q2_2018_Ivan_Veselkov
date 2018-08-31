var pause = false;
var i,t;
var numbPage = 0;
var timeRest = 0;
var moveInterval = 5000;
var timerInterval = 100;

function previouspage() {
    history.back(); 
}
function nextpage() {
    history.forward();
}

function move()
{
	numbPage = parseInt(document.getElementById("page_id").innerText);
	var pagemass = ["First.html","Second.html","Third.html"];
	if(numbPage + 1 < pagemass.length)
	{
		window.location=pagemass[numbPage +1];
	}
	else
	{
		if(confirm("Close?"))
		{
			self.close();
		}
		else{
			window.location = pagemass[0];
		}
	}
}

function changeTimer() {
    if (timeRest <= 0)
        timeRest = moveInterval;
    timeRest = timeRest - timerInterval;
    document.getElementById("timer").innerHTML = ((timeRest) / 1000);
}

function pauseTimer() {
    if (pause) {
        start();
        timeRest = 0;
        document.getElementById("pause").value = "Pause";
        pause = false;
    }
    else {
        clearInterval(i);
        clearTimeout(t);
        document.getElementById("pause").value = "Start";
        pause = true;
    }
}

function start() {
    t = setTimeout(move, moveInterval);
    i = setInterval(changeTimer, timerInterval);
}
start();