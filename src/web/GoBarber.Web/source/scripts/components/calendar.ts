let date: number = 1;
let today: Date;
let currentMonth: number;
let currentYear: number;
let selectedDate: any;

let months: string[] = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
];
let days: string[] = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
let monthAndYear = document.getElementById("monthAndYear");
let calendar: HTMLElement = document.getElementById("calendar");

let btnNext: HTMLButtonElement = document.querySelector(".btn-next");
let btnprevious: HTMLButtonElement = document.querySelector(".btn-previous");

console.log("Calendar");
today = new Date();
currentMonth = today.getMonth();
currentYear = today.getFullYear();

btnNext.onclick = () => {
    next();
};

btnprevious.onclick = () => {
    previous();
};

var dayHeader = "<tr>";
for (let day in days) {
    dayHeader += "<th data-days='" + days[day] + "'>" + days[day] + "</th>";
}
dayHeader += "</tr>";

document.getElementById("thead-month").innerHTML = dayHeader;

showCalendar(currentMonth, currentYear);

function next() {
    currentYear = currentMonth === 11 ? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
}

function previous() {
    currentYear = currentMonth === 0 ? currentYear - 1 : currentYear;
    currentMonth = currentMonth === 0 ? 11 : currentMonth - 1;
    showCalendar(currentMonth, currentYear);
}

function showCalendar(month, year) {
    var firstDay = new Date(year, month).getDay();

    let tbl = document.getElementById("calendar-body");
    tbl.innerHTML = "";

    monthAndYear.innerHTML = months[month] + " " + year;
    var date = 1;

    for (var i = 0; i < 6; i++) {
        var row = document.createElement("tr");

        for (var j = 0; j < 7; j++) {
            if (i === 0 && j < firstDay) {
                let cell = document.createElement("td");
                let cellText = document.createTextNode("");
                cell.appendChild(cellText);
                row.appendChild(cell);
            } else if (date > daysInMonth(month, year)) {
                break;
            } else {
                let cell = document.createElement("td");
                cell.setAttribute("data-date", this.date);
                cell.setAttribute("data-month", month + 1);
                cell.setAttribute("data-year", year);
                cell.setAttribute("data-month_name", months[month]);
                cell.className = "date-picker";
                cell.innerHTML = "<span>" + date + "</span>";

                if (
                    date === today.getDate() &&
                    year === today.getFullYear() &&
                    month === today.getMonth()
                ) {
                    cell.className = "date-picker selected";
                }
                if (cell !== null) {
                    cell.addEventListener("click", (selectedDay: MouseEvent) => {
                        var cellElement = selectedDay.currentTarget as HTMLTableCellElement;
                        this.setSelectedDate(
                            cellElement,
                            parseInt(cellElement.textContent),
                            month,
                            year
                        );
                    });
                }

                row.appendChild(cell);
                date++;
            }
        }

        tbl.appendChild(row);
    }
}

function daysInMonth(iMonth, iYear) {
    return 32 - new Date(iYear, iMonth, 32).getDate();
}

function cleanSelectedDate() {
    let oldSelectedElement: HTMLTableCellElement = this.calendar.querySelector(
        ".selected"
    );
    if (oldSelectedElement !== null) {
        oldSelectedElement.classList.remove("selected");
    }
}

function setSelectedDate(
    element: HTMLTableCellElement,
    day: number,
    month: number,
    year: number
) {
    let oldSelectedElement: HTMLTableCellElement = this.calendar.querySelector(
        ".selected"
    );

    if (oldSelectedElement !== null) {
        oldSelectedElement.classList.remove("selected");
    }

    element.classList.add("selected");

    this.getAppointments(day, month, year)
}

function getAppointments(day: string, month: string, year: string) {
    let url = `https://localhost:3333/appointment/appointmentlist?date=${day}-${month + 1}-${year}`;
    fetch(url, {
        method: "GET",
        headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
        },
    }).then(function (response) {
        return response.text();
    }).then(function (body) {
        document.querySelector('.component-appointments').innerHTML = body;
    });
}