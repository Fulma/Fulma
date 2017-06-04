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

  and Box =
    { container: string }

  and Content =
    { container: string
      size: StandardSize }

  and Delete =
    { container: string
      size: StandardSize }

  and Icon =
    { container: string
      size: StandardSize}

  and Heading =
    { title: string
      subtitle: string
      size: HeadingSize
      spacing: HeadingSpacing }

  and HeadingSize =
    { is1: string
      is2: string
      is3: string
      is4: string
      is5: string
      is6: string }

  and HeadingSpacing =
    { isNormal: string }

  and Tag =
    { container: string
      size: TagSize
      color: LevelAndColor }

  and TagSize =
    { isMedium: string
      isLarge: string }

  and Bulma =
    { box: Box
      content: Content
      delete: Delete
      heading: Heading
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

  let box =
    { container = "box" }

  let content : Content =
    { container = "content"
      size = standardSize }

  let delete : Delete =
    { container = "delete"
      size = standardSize }

  let icon : Icon =
    { container = "icon"
      size = standardSize }

  let heading : Heading =
    { title = "title"
      subtitle = "subtitle"
      size =
        { is1 = "is-1"
          is2 = "is-2"
          is3 = "is-3"
          is4 = "is-4"
          is5 = "is-5"
          is6 = "is-6" }
      spacing =
        { isNormal = "is-spaced" } }

  let tagSize : TagSize =
    { isMedium = "is-medium"
      isLarge = "is-large" }

  let tag : Tag =
    { container = "tag"
      size = tagSize
      color = levelAndColor }

  let bulma =
    { box = box
      content = content
      delete = delete
      icon = icon
      heading = heading
      tag = tag }

  let (++) str1 str2 = str1 + " " + str2
