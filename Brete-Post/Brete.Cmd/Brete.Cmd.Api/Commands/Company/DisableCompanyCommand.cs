﻿using CQRS.Core.Commands;

namespace Brete.Cmd.Api.Commands.Company;

public record DisableCompanyCommand : BaseCommand
{
    public bool IsActive { get; set; }
}
