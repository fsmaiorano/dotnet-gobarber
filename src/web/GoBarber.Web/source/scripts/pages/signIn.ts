interface ILogin {
  email: string;
  password: string;
}

interface LoginResponse extends GenericResult {
  token: string;
}

class SignIn {
  private btnDoLogin: HTMLButtonElement = document.querySelector(".btn-login");
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
      await this.doLogin();
    };
  }

  async doLogin() {
    let data: ILogin = {
      email: this.inputEmail.value,
      password: this.inputPassword.value,
    };

    const rawResponse = await fetch(
      "https://localhost:3333/signin",
      {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          token: "teste",
        },
        body: JSON.stringify(data),
      }
    );
    let response: LoginResponse = await rawResponse.json();

    if (response.success) {
      window.localStorage.setItem("GoBarber.Web:Token", response.token);
    }
  }
}
new SignIn();
