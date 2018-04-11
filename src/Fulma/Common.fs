namespace Fulma

open Fable.Core
open Fable.Helpers.React.Props

[<AutoOpen>]
module Color =

    module Classes =
        let [<Literal>] IsBlack = "is-black"
        let [<Literal>] IsDark = "is-dark"
        let [<Literal>] IsLight = "is-light"
        let [<Literal>] IsWhite = "is-white"
        let [<Literal>] IsPrimary = "is-primary"
        let [<Literal>] IsInfo = "is-info"
        let [<Literal>] IsSuccess = "is-success"
        let [<Literal>] IsWarning = "is-warning"
        let [<Literal>] IsDanger = "is-danger"

    type IColor =
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger
        | NoColor

    let ofColor level =
        match level with
        | IsBlack -> Classes.IsBlack
        | IsDark -> Classes.IsDark
        | IsLight -> Classes.IsLight
        | IsWhite -> Classes.IsWhite
        | IsPrimary -> Classes.IsPrimary
        | IsInfo -> Classes.IsInfo
        | IsSuccess -> Classes.IsSuccess
        | IsWarning -> Classes.IsWarning
        | IsDanger -> Classes.IsDanger
        | NoColor -> ""

[<AutoOpen>]
module Size =

    module Classes =
        let [<Literal>] IsSmall = "is-small"
        let [<Literal>] IsMedium = "is-medium"
        let [<Literal>] IsLarge = "is-large"

    type ISize =
        | IsSmall
        | IsMedium
        | IsLarge

    let ofSize size =
        match size with
        | IsSmall -> Classes.IsSmall
        | IsMedium -> Classes.IsMedium
        | IsLarge -> Classes.IsLarge

[<AutoOpen>]
module Common =
    type GenericOption =
        | CustomClass of string
        | Props of IHTMLProp list

    type GenericOptions =
        { CustomClass : string option
          Props : IHTMLProp list }

        static member Empty =
            { CustomClass = None
              Props = [] }

    let genericParse options =
        let parseOptions (result: GenericOptions ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        options |> List.fold parseOptions GenericOptions.Empty

    module Helpers =

        let classes std (options : string option list) (booleans: (string * bool) list) =
            let std = (std, options) ||> List.fold (fun complete opt ->
                match opt with Some name -> complete + " " + name | None -> complete)
            (std, booleans) ||> List.fold (fun complete (name, flag) ->
                if flag then complete + " " + name else complete)
            |> ClassName :> IHTMLProp

    [<Pojo>]
    type DangerousInnerHtml =
        { __html : string }
