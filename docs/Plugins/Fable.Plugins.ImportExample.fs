module Fable.Plugins.ImportExample

open Fable
open Fable.AST
open Fable.AST.Babel

type ImportExamplePlugins() =
    interface IReplacePlugin with
        member this.TryReplace com (info: Fable.ApplyInfo) =
            addWarning com "Test.fs" None info.ownerFullName
            None

    // interface IDeclarePlugin with
    //     member this.TryDeclare com  ctx decl =
    //         None
            // match info.ownerFullName with

            // | "App.View.ExampleCodeAttribute" ->
            //     // ccall info "String" "printf" [info.args.Head] |> Some
            //     addWarning com "Test.fs" None info.ownerFullName
            //     None
            // | _ -> None
