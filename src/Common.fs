namespace Elmish.Bulma

open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Helpers.React.Props

module Common =
    type ISize =
        | IsSmall
        | IsMedium
        | IsLarge
        | Nothing

    type ILevelAndColor =
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger
        | Nothing

    let ofLevelAndColor level =
        match level with
        | IsBlack -> bulma.Modifiers.Color.IsBlack
        | IsDark -> bulma.Modifiers.Color.IsDark
        | IsLight -> bulma.Modifiers.Color.IsLight
        | IsWhite -> bulma.Modifiers.Color.IsWhite
        | IsPrimary -> bulma.Modifiers.Color.IsPrimary
        | IsInfo -> bulma.Modifiers.Color.IsInfo
        | IsSuccess -> bulma.Modifiers.Color.IsSuccess
        | IsWarning -> bulma.Modifiers.Color.IsWarning
        | IsDanger -> bulma.Modifiers.Color.IsDanger
        | ILevelAndColor.Nothing -> ""

    let ofSize size =
        match size with
        | IsSmall -> bulma.Modifiers.Size.IsSmall
        | IsMedium -> bulma.Modifiers.Size.IsMedium
        | IsLarge -> bulma.Modifiers.Size.IsLarge
        | ISize.Nothing -> ""

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
        let inline generateClassName baseClass (values : string option list) =
            baseClass :: (values
                          |> List.filter (fun x -> x.IsSome)
                          |> List.map (fun x -> x.Value))
            |> String.concat " "
