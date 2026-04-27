const TOKEN_STORAGE_KEY = "companyTest.token";
const USER_ID_STORAGE_KEY = "companyTest.userId";

export const authStorage = {
  getToken(): string | null {
    if (typeof window === "undefined") return null;
    return localStorage.getItem(TOKEN_STORAGE_KEY);
  },
  setToken(token: string) {
    localStorage.setItem(TOKEN_STORAGE_KEY, token);
  },
  clearToken() {
    localStorage.removeItem(TOKEN_STORAGE_KEY);
  },
  getUserId(): string | null {
    if (typeof window === "undefined") return null;
    return localStorage.getItem(USER_ID_STORAGE_KEY);
  },
  setUserId(userId: string) {
    localStorage.setItem(USER_ID_STORAGE_KEY, userId);
  },
  clearUserId() {
    localStorage.removeItem(USER_ID_STORAGE_KEY);
  },
  clearAll() {
    authStorage.clearToken();
    authStorage.clearUserId();
  },
};

