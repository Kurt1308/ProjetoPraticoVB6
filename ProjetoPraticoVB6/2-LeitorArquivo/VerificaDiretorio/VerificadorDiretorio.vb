﻿Imports ProjetoPraticoVB6.Logs
Imports System.IO

Namespace Serviços
    Public Class VerificadorDiretorio
        Implements IVerificadorDiretorio

        Private logger As IGeraLog ' Campo para o logger

        Public Sub New(logger As IGeraLog)
            Me.logger = logger
        End Sub

        Public Function VerificarDiretorio(path As String) As Boolean Implements IVerificadorDiretorio.VerificarDiretorio
            If Directory.Exists(path) Then
                Return True
            Else
                logger.Log($"Diretório não encontrado: {path}")
                Return False
            End If
        End Function
    End Class
End Namespace

