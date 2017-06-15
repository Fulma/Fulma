namespace Elmish.Bulma

open Elmish.Bulma.BulmaClasses
open Fable.Core

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

    module Helpers =
        let inline generateClassName baseClass (values : string option list) =
            baseClass :: (values
                          |> List.filter (fun x -> x.IsSome)
                          |> List.map (fun x -> x.Value))
            |> String.concat " "
