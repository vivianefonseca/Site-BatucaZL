using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BatucaZL.Site.Services;

namespace BatucaZL.Logger
{
  public class EmailLogger : ILogger
  {
    private string _categoryName;
    private Func<string, LogLevel, bool> _filter;
    private IEmailService _emailService;

    public EmailLogger(string categoryName, Func<string, LogLevel, bool> filter, IEmailService emailService)
    {
      _categoryName = categoryName;
      _filter = filter;
      _emailService = emailService;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
      // Not necessary
      return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      return (_filter == null || _filter(_categoryName, logLevel));
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
      if (!IsEnabled(logLevel))
      {
        return;
      }

      if (formatter == null)
      {
        throw new ArgumentNullException(nameof(formatter));
      }

      var message = formatter(state, exception);

      if (string.IsNullOrEmpty(message))
      {
        return;
      }

      message = $@"Level: {logLevel}

{message}";

      if (exception != null)
      {
        message += Environment.NewLine + Environment.NewLine + exception.ToString();
      }

      _emailService.EnviarEmail("Viviane", "viviane.dsfonseca@gmail.com", "[BatucaZL Erro]", message);

    }
  }
}