class SignIn {
  private btnDoLogin: HTMLButtonElement = document.querySelector(".btn-login");
  private frmLogin: HTMLFormElement = document.querySelector(".form");
  private input: HTMLInputElement = document.querySelector(".input");

  constructor() {
    this.init();
  }

  init() {
    this.btnDoLogin.addEventListener("click", (x) => {
      debugger;
    });
    // this.btnDoLogin.addEventListener = () => {
    //   console.log("click");
    // };
  }
}

new SignIn();
