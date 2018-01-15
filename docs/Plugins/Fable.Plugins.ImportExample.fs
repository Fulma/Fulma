module Fable.Plugins.ImportExample

open System
open System.IO
open Fable
open Fable.AST
open Fable2Babel

type ImportExamplePlugins() =
    // interface IReplacePlugin with
    //     member __.TryReplace _com (info: Fable.ApplyInfo) =
    //         match info.ownerType, info.methodName with
    //         | Fable.DeclaredType(ent,_), "renderView" ->
    //             let args = failwith "MY CUSTOM ARGS"
    //             let owner = Fable.Value(Fable.TypeRef(ent,[]))
    //             Some <| Fable.Apply(owner, args, Fable.ApplyMeth, info.returnType, info.range)
    //         | _ -> None
    interface IDeclarePlugin with

        member __.TryDeclareRoot _com _ctx _file =
            None
        member __.TryDeclare _com ctx decl =
            match decl with
            | Fable.MemberDeclaration(m,_,_,_,_,Some r) ->
                if m.Decorators |> List.exists (fun x -> x.Name.Contains("ExampleCode")) then
                    let text =
                        File.ReadLines(ctx.file.SourcePath)
                        |> Seq.skip r.start.line
                        |> Seq.takeWhile (String.IsNullOrWhiteSpace >> not)
                        |> String.concat "\n"
                    let body =
                        Babel.BlockStatement [Babel.ReturnStatement (Babel.StringLiteral text)]
                    Babel.FunctionDeclaration(Babel.Identifier m.Name, [], body) :> Babel.Statement
                    |> List.singleton |> Some
                else None
            | _ -> None
