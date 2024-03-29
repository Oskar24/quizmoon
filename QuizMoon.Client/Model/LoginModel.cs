﻿using System.ComponentModel.DataAnnotations;

namespace QuizMoon.Client.Model;

public class LoginModel
{
    [Required]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
    
    public bool RememberLogin { get; set; }
}