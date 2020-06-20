class SignIn {
  private btnDoLogin: HTMLButtonElement = document.querySelector(".btn-login");
  private frmLogin: HTMLFormElement = document.querySelector(".form");
  private inputEmail: HTMLInputElement = document.querySelector(".input-email");
  private inputPassword: HTMLInputElement = document.querySelector(
    ".input-password"
  );

  constructor() {
    this.init();
  }

  init() {
    this.inputEmail.addEventListener("change", (event: Event) => {
      let input = event.target as HTMLInputElement;

      if (input.value !== "") {
        input.parentElement.classList.add("input-focused");
      } else {
        input.parentElement.classList.remove("input-focused");
      }
    });

    this.inputPassword.addEventListener("change", (event: Event) => {
      let input = event.target as HTMLInputElement;

      if (input.value !== "") {
        input.parentElement.classList.add("input-focused");
      } else {
        input.parentElement.classList.remove("input-focused");
      }
    });

    this.btnDoLogin.onclick = async () => {
      debugger;
      var opts: RequestInit = {
        method: "POST",
        headers: new Headers({
          Accept: "application/json",
          "Content-Type": "application/json",
        }),
        mode: "no-cors",
        body: JSON.stringify({
          email: this.inputEmail,
          password: this.inputEmail,
          token: "",
        }),
      };
      await fetch("https://localhost:5001/api/Authentication", opts)
        .then(function (response) {
          debugger;
          return response.json();
        })
        .then(function (body) {
          debugger;
          //doSomething with body;
        });
    };
  }
}

new SignIn();
