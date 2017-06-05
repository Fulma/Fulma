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

  let ofLevel level =
    match level with
    | IsBlack -> bulma.button.color.isBlack
    | IsDark -> bulma.button.color.isDark
    | IsLight -> bulma.button.color.isLight
    | IsWhite -> bulma.button.color.isWhite
    | IsPrimary -> bulma.button.color.isPrimary
    | IsInfo -> bulma.button.color.isInfo
    | IsSuccess -> bulma.button.color.isSuccess
    | IsWarning -> bulma.button.color.isWarning
    | IsDanger -> bulma.button.color.isDanger
    | ILevelAndColor.Nothing -> ""

  let ofSize size =
    match size with
    | IsSmall -> bulma.button.size.isSmall
    | IsMedium -> bulma.button.size.isMedium
    | IsLarge -> bulma.button.size.isLarge
    | ISize.Nothing -> ""
