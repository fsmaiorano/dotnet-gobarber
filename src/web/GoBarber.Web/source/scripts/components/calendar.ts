class Calendar {
    date: number = 1;
    today: Date;
    currentMonth: number;
    currentYear: number;
    selectedDate: any;

    months: string[] = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    days: string[] = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
    monthAndYear = document.getElementById("monthAndYear");
    calendar: HTMLElement = document.getElementById("calendar");

    //btnNext: HTMLButtonElement = document.querySelector(".btn-next");
    //btnprevious: HTMLButtonElement = document.querySelector(".btn-previous");

    constructor() {
        this.init();
    }

    init() {
        console.log("Calendar");
        this.today = new Date();
        this.currentMonth = this.today.getMonth();
        this.currentYear = this.today.getFullYear();

        //this.btnNext.onclick = () => {
        //    this.next();
        //};

        //this.btnprevious.onclick = () => {
        //    this.previous();
        //};

        var dayHeader = "<tr>";
        for (let day in this.days) {
            dayHeader += "<th data-days='" + this.days[day] + "'>" + this.days[day] + "</th>";
        }
        dayHeader += "</tr>";

        document.getElementById("thead-month").innerHTML = dayHeader;

        this.showCalendar(this.currentMonth, this.currentYear);
    }

    public next() {
        this.currentYear = (this.currentMonth === 11) ? this.currentYear + 1 : this.currentYear;
        this.currentMonth = (this.currentMonth + 1) % 12;
        this.showCalendar(this.currentMonth, this.currentYear);
    }

    public previous() {
        this.currentYear = (this.currentMonth === 0) ? this.currentYear - 1 : this.currentYear;
        this.currentMonth = (this.currentMonth === 0) ? 11 : this.currentMonth - 1;
        this.showCalendar(this.currentMonth, this.currentYear);
    }

    public showCalendar(month, year) {
        var firstDay = (new Date(year, month)).getDay();

        let tbl = document.getElementById("calendar-body");
        tbl.innerHTML = "";

        this.monthAndYear.innerHTML = this.months[month] + " " + year;

        for (var i = 0; i < 6; i++) {
            let row = document.createElement("tr");

            for (var j = 0; j < 7; j++) {
                if (i === 0 && j < firstDay) {
                    let cell: HTMLTableCellElement = document.createElement("td");
                    let cellText = document.createTextNode("");
                    cell.appendChild(cellText);
                    row.appendChild(cell);
                } else if (this.date > this.daysInMonth(month, year)) {
                    break;
                } else {
                    let cell: HTMLTableCellElement = document.createElement("td");
                    cell.setAttribute("data-date", this.date.toString());
                    cell.setAttribute("data-month", month + 1);
                    cell.setAttribute("data-year", year);
                    cell.setAttribute("data-month_name", this.months[month]);
                    cell.className = "date-picker";
                    cell.innerHTML = "<span>" + this.date + "</span>";

                    if (this.date === this.today.getDate() && year === this.today.getFullYear() && month === this.today.getMonth()) {
                        cell.className = "date-picker selected";
                    }

                    cell.addEventListener("click", (selectedDay: MouseEvent) => {
                        var cellElement = selectedDay.currentTarget as HTMLTableCellElement;
                        this.setSelectedDate(cellElement, parseInt(cellElement.textContent), month + 1, year);
                    });

                    row.appendChild(cell);
                    this.date++;
                }
            }

            tbl.appendChild(row);
        }
    }

    public daysInMonth(iMonth, iYear) {
        return 32 - new Date(iYear, iMonth, 32).getDate();
    }

    public setSelectedDate(element: HTMLTableCellElement, day: number, month: number, year: number) {
        let oldSelectedElement: HTMLTableCellElement = this.calendar.querySelector('.selected');
        oldSelectedElement.classList.remove('selected');
        element.classList.add('selected');
    }
}
new Calendar();