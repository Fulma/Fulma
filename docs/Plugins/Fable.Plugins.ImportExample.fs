module Fable.Plugins.ImportExample

open System
open System.IO
open Fable
open Fable.AST
open Fable2Babel

type ImportExamplePlugins() =
    interface IDeclarePlugin with
        member __.TryDeclareRoot _com _ctx _file =
            None
        member __.TryDeclare _com ctx decl =
            match decl with
            | Fable.MemberDeclaration(m,_,_,_,_,Some r) ->
                if m.Decorators |> List.exists (fun x -> x.Name.Contains("ExampleCode")) then
                    printfn "===================="
                    printfn "EXAMPLE: %s" m.Name
                    File.ReadLines(ctx.file.SourcePath)
                    |> Seq.skip r.start.line
                    |> Seq.takeWhile (String.IsNullOrWhiteSpace >> not)
                    |> Seq.iter (printfn "%s")
                    printfn "===================="
                    // transformTest com ctx (test, decorator, args, body, range)
                    // |> List.singleton |> Some
                    Some [Babel.ExpressionStatement(Babel.NullLiteral())]
                else None
            | _ -> None
