# Async Method Library

---------------------------------------

C# 비동기 래퍼 메서드 생성기

## 기능

- 동기 메서드의 비동기 래퍼 메서드를 생성합니다.
- 한 마디로, [이런 코드](https://github.com/cplkimth/AsyncMethodLibrary/blob/main/ForDotnetCore/InstanceClass.cs)를 가지고 [이런 코드](https://github.com/cplkimth/AsyncMethodLibrary/blob/main/ForDotnetCore/generated/InstanceClass.async.cs)를 만들 수 있습니다.
- .Net Standard 2.0을 지원합니다. 따라서 .Net Framework 4.6.1 이상, .Net Core 2.0 이상에서 사용할 수 있습니다.)
- 매개변수와 리턴값에 제네릭 파라미터가 있는 메서드의 래퍼 메서드를 생성합니다.
- 확장 메서드의 비동기 래퍼도 생성할 수 있습니다.

## 사용방법
1. 프로젝트에 [Nuget 패키지](https://www.nuget.org/packages/AsyncMethodLibrary/)를 추가합니다.
2. 비동기 메서드를 생성할 동기 메서드에 `ForAsync` 특성을 추가합니다.
```csharp
[ForAsync]
public List<int> GenericReturn(int a, int b)
```
3. `Generator.Generate` 메서드를 호출하면 코드가 생성되고 디렉토리에 저장됩니다.
```csharp
Generator.Generate(@".\generated", typeof(StaticClass));
```
4. 한 개 이상의 타입을 지정할 수도 있는데, 이 경우 타입 한 개당 하나의 파일이 생성됩니다.
```csharp
Generator.Generate(@".\generated", typeof(StaticClass), typeof(InstanceClass));
```
5. 어셈블리를 전달하면 어셈블리 안에 있는 모든 타입에 대해서 코드를 생성합니다.
```csharp
Generator.Generate(@".\generated", Assembly.GetExecutingAssembly());
```
6. c#의 타입이 아닌 닷넷 프레임워크의 타입을 사용하기 때문에 생성된 코드가 장황합니다. 동작에는 문제가 없지만, [Resharper](https://www.jetbrains.com/ko-kr/resharper/) 등의 툴이나, [Rider](https://www.jetbrains.com/ko-kr/rider/) 같은 IDE에서 제공하는 코드 정리 기능을 사용하여 코드를 간결하게 유지할 수 있습니다.
