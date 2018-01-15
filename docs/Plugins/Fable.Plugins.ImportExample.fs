module Plugins.ImportExample

open System
open System.IO
open System.Text.RegularExpressions
open Fable
open Fable.AST
open Fable.AST.Fable
open Fable2Babel

type ImportExamplePlugins() =
    interface IReplacePlugin with
        member __.TryReplace _com (info: ApplyInfo) =
            match info.methodName with
            | "getViewSource" ->
                // printfn "ARGS: %A" info.args
                match info.args with
                | [Value(Lambda(_,Apply(Value(IdentValue view),_,_,_,_),_))] ->
                    let reg = Regex("let " + view.Name + @"\s*\(\)\s*=")
                    // printfn "REGEX: %s" (string reg)
                    // printfn "FILE: %s" info.fileName
                    let source =
                        File.ReadLines(info.fileName)
                        |> Seq.skipWhile (reg.IsMatch >> not)
                        |> Seq.skip 1
                        |> Seq.takeWhile (String.IsNullOrWhiteSpace >> not)
                        |> String.concat "\n"
                    StringConst source |> Value |> Some
                | _ -> None
            | _ -> None
    // interface IDeclarePlugin with
    //     member __.TryDeclareRoot _com _ctx _file =
    //         None
    //     member __.TryDeclare _com ctx decl =
    //         match decl with
    //         | MemberDeclaration(m,_,_,_,_,Some r) ->
    //             if m.Decorators |> List.exists (fun x -> x.Name.Contains("ExampleCode")) then
    //                 let text =
    //                     File.ReadLines(ctx.file.SourcePath)
    //                     |> Seq.skip r.start.line
    //                     |> Seq.takeWhile (String.IsNullOrWhiteSpace >> not)
    //                     |> String.concat "\n"
    //                 let body =
    //                     Babel.BlockStatement [Babel.ReturnStatement (Babel.StringLiteral text)]
    //                 Babel.FunctionDeclaration(Babel.Identifier m.Name, [], body) :> Babel.Statement
    //                 |> List.singleton |> Some
    //             else None
    //         | _ -> None
