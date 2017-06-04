namespace Elmish.Bulma

module BulmaClasses =

  type StandardSize =
    { isSmall: string
      isMedium: string
      isLarge: string }

  and Icon =
    { container: string
      size: StandardSize}

  and Delete =
    { container: string
      size: StandardSize }

  and Bulma =
    { icon: Icon
      delete: Delete }

  let standardSize =
    { isSmall = "is-small"
      isMedium = "is-medium"
      isLarge = "is-large " }

  let icon : Icon =
    { container = "icon"
      size = standardSize }

  let delete : Delete =
    { container = "delete"
      size = standardSize }

  let bulma =
    { icon = icon
      delete = delete }
