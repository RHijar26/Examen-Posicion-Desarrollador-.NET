﻿using MediatR;

namespace ExamenDesarrollador.Bussiness.Configuration.Commands
{
    public interface ICommand : IRequest
    {
      

    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {           

    }
}
