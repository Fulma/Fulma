namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Title =

    // Possible sizes
    [<StringEnum>]
    type TitleSize =
    | [<CompiledName("is-1")>] Is1
    | [<CompiledName("is-2")>] Is2
    | [<CompiledName("is-3")>] Is3
    | [<CompiledName("is-4")>] Is4
    | [<CompiledName("is-5")>] Is5
    | [<CompiledName("is-6")>] Is6
    | [<CompiledName("")>] None

    // Possible types
    [<StringEnum>]
    type TitleType =
    | [<CompiledName("title")>] Title
    | [<CompiledName("subtitle")>] SubTitle

    type Option =
    | TitleSize of TitleSize
    | TitleType of TitleType
    | IsSpaced

    type Options =
      { TitleSize : TitleSize
        TitleType : TitleType
        IsSpaced : bool }
      static member Empty =
        { TitleSize = TitleSize.None
          TitleType = TitleType.Title
          IsSpaced = false }

    let title (element:IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options: Option list) (properties: IHTMLProp list) (children) =
        let parseOption result opt=
          match opt with
          | TitleSize ts ->
              { result with TitleSize = ts }
          | TitleType tt ->
              { result with TitleType = tt }
          | IsSpaced ->
              { result with IsSpaced = true }

        let opts = options |> List.fold parseOption Options.Empty

        let className =
          classBaseList
            (sprintf "%s %s" (unbox<string>opts.TitleSize) (unbox<string>opts.TitleType))
            [ "is-spaced", opts.IsSpaced ]

        element
          ((className :> IHTMLProp) :: properties)
          children
