import Swal from "sweetalert2";

export const alert = {
  success(message: string) {
    return Swal.fire({
      title: "Sucesso!",
      text: message,
      icon: "success",
      confirmButtonColor: "#2563eb",
    });
  },

  error(message: string) {
    return Swal.fire({
      title: "Erro",
      text: message,
      icon: "error",
      confirmButtonColor: "#dc2626",
    });
  },

  warning(message: string) {
    return Swal.fire({
      title: "Atenção",
      text: message,
      icon: "warning",
      confirmButtonColor: "#f59e0b",
    });
  },

  async confirm(message: string) {
    const result = await Swal.fire({
      title: "Confirmação",
      text: message,
      icon: "question",
      showCancelButton: true,
      confirmButtonText: "Sim",
      cancelButtonText: "Cancelar",
      confirmButtonColor: "#2563eb",
      cancelButtonColor: "#6b7280",
    });

    return result.isConfirmed;
  },
};