// Recursive Type Definitions  pg. 55

module RecursiveTypeDefinitions

// Reprsents an XML attribute
type XmlAttribute =
    { AttribName: string
      AttribVale: string }

// represents an XML element
type XmlElement =
    { Element: string
      Attributes: list<XmlAttribute>
      InnerXml: XmlTree }

// represents an XML tree
and XmlTree =
    | Element of XmlElement
    | ElementList of list<XmlTree>
    | Text of string
    | Cooment of string
    | Empty
