import AuthRepositorie from "../repositories/AuthRepositorie";

class AuthService {
  async Login(userName: string, password: string) {
    return AuthRepositorie.Login(userName, password);
  }
}

export default new AuthService();
