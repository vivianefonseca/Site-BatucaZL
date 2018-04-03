using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BatucaZL.Site.Services;

namespace BatucaZL.Logger
{
  public class EmailLoggerProvider : ILoggerProvider
  {
    private readonly Func<string, LogLevel, bool> _filter;
    private readonly IEmailService _emailService;

    public EmailLoggerProvider(Func<string, LogLevel, bool> filter, IEmailService emailService)
    {
      _emailService = emailService;
      _filter = filter;
    }

    public ILogger CreateLogger(string categoryName)
    {
      return new EmailLogger(categoryName, _filter, _emailService);
    }

    public void Dispose()
    {
    }
  }
}
