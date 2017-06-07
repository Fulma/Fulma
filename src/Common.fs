namespace Elmish.Bulma

open Fable.Core
open Elmish.Bulma.BulmaClasses

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
    | IsBlack -> bulma.modifiers.color.isBlack
    | IsDark -> bulma.modifiers.color.isDark
    | IsLight -> bulma.modifiers.color.isLight
    | IsWhite -> bulma.modifiers.color.isWhite
    | IsPrimary -> bulma.modifiers.color.isPrimary
    | IsInfo -> bulma.modifiers.color.isInfo
    | IsSuccess -> bulma.modifiers.color.isSuccess
    | IsWarning -> bulma.modifiers.color.isWarning
    | IsDanger -> bulma.modifiers.color.isDanger
    | ILevelAndColor.Nothing -> ""

  let ofSize size =
    match size with
    | IsSmall -> bulma.modifiers.size.isSmall
    | IsMedium -> bulma.modifiers.size.isMedium
    | IsLarge -> bulma.modifiers.size.isLarge
    | ISize.Nothing -> ""

  module Helpers =

    let inline generateClassName baseClass (values: (string option) list) =
      baseClass
      :: (
        values
        |> List.filter (fun x -> x.IsSome)
        |> List.map (fun x -> x.Value)
      )
      |> String.concat " "
