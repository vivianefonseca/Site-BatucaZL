using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BatucaZL.Site.Services;

namespace BatucaZL.Logger
{
  public static class EmailLoggerExtensions
  {
    public static ILoggerFactory AddEmail(this ILoggerFactory factory, 
                                          IEmailService emailService, 
                                          Func<string, LogLevel, bool> filter = null)
    {
      factory.AddProvider(new EmailLoggerProvider(filter, emailService));
      return factory;
    }

    public static ILoggerFactory AddEmail(this ILoggerFactory factory, IEmailService emailService, LogLevel minLevel)
    {
      return AddEmail(
          factory,
          emailService,
          (_, logLevel) => logLevel >= minLevel);
    }
  }
}
