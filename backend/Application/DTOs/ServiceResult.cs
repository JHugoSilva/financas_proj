namespace financas.Application.DTOs;

/// <summary>
/// Representa o resultado de uma operação executada pela camada de serviço.
/// Encapsula o status da operação, uma mensagem informativa e os dados
/// retornados, quando houver.
/// </summary>
/// <typeparam name="T">
/// Tipo do objeto retornado pela operação.
/// </typeparam>
public class ServiceResult<T>
{
  /// <summary>
  /// Indica se a operação foi executada com sucesso.
  /// </summary>
  public bool Success { get; set; }

  /// <summary>
  /// Mensagem descritiva do resultado da operação.
  /// Pode conter informações de sucesso, aviso ou erro.
  /// </summary>
  public string? Message { get; set; }

  /// <summary>
  /// Dados retornados pela operação.
  /// Será <c>null</c> quando não houver conteúdo ou quando a operação falhar.
  /// </summary>
  public T? Data { get; set; }
}