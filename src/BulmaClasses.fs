namespace Elmish.Bulma

module BulmaClasses =

  type StandardSize =
    { isSmall: string
      isMedium: string
      isLarge: string }

  and LevelAndColor =
    { isBlack: string
      isDark: string
      isLight: string
      isWhite: string
      isPrimary: string
      isInfo: string
      isSuccess: string
      isWarning: string
      isDanger: string }

  and Icon =
    { container: string
      size: StandardSize}

  and Delete =
    { container: string
      size: StandardSize }

  and Tag =
    { container: string
      size: TagSize
      color: LevelAndColor }

  and TagSize =
    { isMedium: string
      isLarge: string }

  and Bulma =
    { delete: Delete
      icon: Icon
      tag: Tag }

  let standardSize =
    { isSmall = "is-small"
      isMedium = "is-medium"
      isLarge = "is-large " }

  let levelAndColor =
    { isBlack = "is-black"
      isDark = "is-dark"
      isLight = "is-light"
      isWhite = "is-white"
      isPrimary = "is-primary"
      isInfo = "is-info"
      isSuccess = "is-success"
      isWarning = "is-warning"
      isDanger = "is-danger" }

  let icon : Icon =
    { container = "icon"
      size = standardSize }

  let delete : Delete =
    { container = "delete"
      size = standardSize }

  let tagSize : TagSize =
    { isMedium = "is-medium"
      isLarge = "is-large" }

  let tag : Tag =
    { container = "tag"
      size = tagSize
      color = levelAndColor }

  let bulma =
    { delete = delete
      icon = icon
      tag = tag }

  let (++) str1 str2 = str1 + " " + str2
