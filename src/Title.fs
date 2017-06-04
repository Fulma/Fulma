namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Title =

    //posible sizes
    [<StringEnum>]
    type TitleSize =
    | [<CompiledName("is-1")>] Is1
    | [<CompiledName("is-2")>] Is2
    | [<CompiledName("is-3")>] Is3
    | [<CompiledName("is-4")>] Is4
    | [<CompiledName("is-5")>] Is5
    | [<CompiledName("is-6")>] Is6
    | [<CompiledName("")>] None

    //posible types
    [<StringEnum>]
    type TitleType =
    | [<CompiledName("title")>] Title
    | [<CompiledName("subtitle")>] SubTitle

    //Title may have extra attributes like this in future
    [<StringEnum>]
    type TitleExtra =
    | [<CompiledName("is-spaced")>] IsSpaced
    | [<CompiledName("")>] None

    type Option =
    | TitleSize of TitleSize
    | TitleType of TitleType
    | TitleExtra of TitleExtra

    type Options = {
        TitleSize : TitleSize
        TitleType : TitleType
        TitleExtra : TitleExtra
    } with
        static member Empty = {
            TitleSize = TitleSize.None
            TitleType = TitleType.Title
            TitleExtra = TitleExtra.None
        }

    let title (element:IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options: Option list) (properties: IHTMLProp list) (children) =
        let parseOption result opt=
            match opt with
            | TitleSize ts ->
                {result with TitleSize = ts }
            | TitleType tt ->
                {result with TitleType = tt }
            | TitleExtra te ->
                {result with TitleExtra = te }
        // let rec parseOptions options result =
        //   match options with
        //   | x::xs ->
        //     match x with
        //     | TitleSize titlesize ->
        //         {result with TitleSize = titlesize }
        //     | TitleType titletype ->
        //         {result with TitleType = titletype }
        //     | TitleExtra titleextra ->
        //         {result with TitleExtra = titleextra }
        //     |> parseOptions xs
        //   | [] -> result

        let opts = options |> List.fold parseOption Options.Empty

        let className =
            ClassName (sprintf "%s %s %s" (unbox<string>opts.TitleSize) (unbox<string>opts.TitleType) (unbox<string>opts.TitleExtra))

        element
          ((className :> IHTMLProp) :: properties)
          children