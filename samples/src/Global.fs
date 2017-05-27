module Global

type Page =
  | Home

let toHash page =
  match page with
  | Home -> "#home"
