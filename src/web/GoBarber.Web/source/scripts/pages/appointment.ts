class Appointment {
  constructor() {
    let currentDay: number = today.getDate();
    let currentMonth: number = today.getMonth();
    let currentYear: number = today.getFullYear();
    this.init(currentDay, currentMonth, currentYear);
  }

  init(currentDay: number, currentMonth: number, currentYear: number) {
    let today: Date = new Date();

    let url = `https://localhost:3333/appointment/appointmentlist?date=${currentDay}-${
      currentMonth + 1
    }-${currentYear}`;
    fetch(url, {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    })
      .then(function (response) {
        return response.text();
      })
      .then(function (body) {
        document.querySelector(".component-appointments").innerHTML = body;
        let appointments: NodeListOf<HTMLDivElement> = document.querySelectorAll(
          ".appointment"
        );

        for (let i = 0; i < appointments.length; i++) {
          appointments[i].addEventListener("click", (event: MouseEvent) => {
            let id = event.currentTarget["id"];
            let url = `https://localhost:3333/appointment/appointmentdetail/${id}`;
            fetch(url, {
              method: "GET",
              headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
              },
            })
              .then(function (response) {
                return response.text();
              })
              .then(function (body) {
                let appointmentList: HTMLDivElement = document.querySelector(
                  ".appointments-list"
                );
                let appointmentInfo: HTMLDivElement = document.querySelector(
                  ".appointment-info"
                );
                appointmentList.style.display = "none";
                appointmentInfo.innerHTML = body;
                appointmentInfo.style.display = "block";

                let btnGoBack: HTMLButtonElement = document.querySelector(
                  ".btn-goback"
                );
                btnGoBack.onclick = () => {
                  let appointmentList: HTMLDivElement = document.querySelector(
                    ".appointments-list"
                  );
                  let appointmentInfo: HTMLDivElement = document.querySelector(
                    ".appointment-info"
                  );
                  appointmentList.style.display = "block";
                  appointmentInfo.style.display = "none";
                };
              });
          });
        }
      });
  }
}
new Appointment();
