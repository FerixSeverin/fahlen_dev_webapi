using System;

namespace fahlen_dev_webapi.Options
{
  public class JwtSettings
  {
    public string Secret { get; set; }

    public TimeSpan TokenLifeTime { get; set; } 
  }
}