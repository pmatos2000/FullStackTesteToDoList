import AuthRepositorie from "../repositories/AuthRepositorie";

class AuthService {
  async login(userName: string, password: string) {
    return AuthRepositorie.login(userName, password);
  }

  async register(userName: string, password: string) {
    return await AuthRepositorie.register(userName, password);
  }
}

export default new AuthService();
