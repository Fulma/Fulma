module Elements.Image.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Image
A container for **responsive** images
      "
    textSize = "## Fixed square images"
    codeSize =
      """
```fsharp
Image.image
  [ Image.is64x64 ]
  [ img
      [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ]
Image.image
  [ Image.is128x128 ]
  [ img
      [ Src "https://dummyimage.com/128x128/7a7a7a/fff" ] ]
```
      """
    textRatio = "## Responsive images with ratios"
    codeRatio =
      """
```fsharp
Image.image
  [ Image.is2by1 ]
  [ img
      [ Src "https://dummyimage.com/640x320/7a7a7a/fff" ] ]
```
      """ }
