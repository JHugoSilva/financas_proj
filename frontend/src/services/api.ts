import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5161/api",
  headers: {
    "Content-Type": "application/json",
  },
});

api.interceptors.response.use((response) => response, (error) => {
  if (axios.isAxiosError(error)) {
    const message = error.response?.data?.message ??
      error.response?.data?.Message ??
      "Erro ao processar a requisição."

    return Promise.reject(new Error(message))
  }

  return Promise.reject(new Error("Erro inesperado."))
})

export default api;