interface ICreateUser {
  user: string;
  email: string;
  password: string;
}

interface LoginResponse extends GenericResult {
  token: string;
}

class SignUp {
  private btnDoLogin: HTMLButtonElement = document.querySelector(".btn-login");
  private inputUser: HTMLInputElement = document.querySelector(".input-user");
  private inputEmail: HTMLInputElement = document.querySelector(".input-email");
  private inputPassword: HTMLInputElement = document.querySelector(
    ".input-password"
  );

  constructor() {
    this.init();
  }

  init() {
    this.inputUser.addEventListener("change", (event: Event) => {
      let input = event.target as HTMLInputElement;

      if (input.value !== "") {
        input.parentElement.classList.add("input-focused");
      } else {
        input.parentElement.classList.remove("input-focused");
      }
    });

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
      this.btnDoLogin.disabled = true;
      this.btnDoLogin.textContent = "Loading...";
      await this.doLogin();
    };
  }

  async doLogin() {
    try {
      let data: ICreateUser = {
        user: this.inputUser.value,
        email: this.inputEmail.value,
        password: this.inputPassword.value,
      };

      const rawResponse = await fetch("https://localhost:3333/signup", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          token: "teste",
        },
        body: JSON.stringify(data),
      });
      let response: LoginResponse = await rawResponse.json();

      if (response.success) {
        window.localStorage.setItem("GoBarber.Web:Token", response.token);
      }
    } catch (e) {
    } finally {
      this.btnDoLogin.disabled = false;
      this.btnDoLogin.textContent = "Login";
    }
  }
}
new SignUp();
