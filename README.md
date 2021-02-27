# Async Method Library

---------------------------------------

C# �񵿱� ���� �޼��� ������

## ���

- ���� �޼����� �񵿱� ���� �޼��带 �����մϴ�.
- �� �����, [�̷� �ڵ�](https://github.com/cplkimth/AsyncMethodLibrary/blob/main/ForDotnetCore/InstanceClass.cs)�� ������ [�̷� �ڵ�](https://github.com/cplkimth/AsyncMethodLibrary/blob/main/ForDotnetCore/generated/InstanceClass.async.cs)�� ���� �� �ֽ��ϴ�.
- .Net Standard 2.0�� �����մϴ�. ���� .Net Framework 4.6.1 �̻�, .Net Core 2.0 �̻󿡼� ����� �� �ֽ��ϴ�.)
- �Ű������� ���ϰ��� ���׸� �Ķ���Ͱ� �ִ� �޼����� ���� �޼��带 �����մϴ�.
- Ȯ�� �޼����� �񵿱� ���۵� ������ �� �ֽ��ϴ�.

## �����
1. ������Ʈ�� [Nuget ��Ű��](https://www.nuget.org/packages/AsyncMethodLibrary/)�� �߰��մϴ�.
2. �񵿱� �޼��带 ������ ���� �޼��忡 `ForAsync` Ư���� �߰��մϴ�.
```csharp
[ForAsync]
public List<int> GenericReturn(int a, int b)
```
3. `Generator.Generate` �޼��带 ȣ���ϸ� �ڵ尡 �����ǰ� ���丮�� ����˴ϴ�.
```csharp
Generator.Generate(@".\generated", typeof(StaticClass));
```
4. �� �� �̻��� Ÿ���� ������ ���� �ִµ�, �� ��� Ÿ�� �� ���� �ϳ��� ������ �����˴ϴ�.
```csharp
Generator.Generate(@".\generated", typeof(StaticClass), typeof(InstanceClass));
```
5. ������� �����ϸ� ����� �ȿ� �ִ� ��� Ÿ�Կ� ���ؼ� �ڵ带 �����մϴ�.
```csharp
Generator.Generate(@".\generated", Assembly.GetExecutingAssembly());
```
6. c#�� Ÿ���� �ƴ� ��� �����ӿ�ũ�� Ÿ���� ����ϱ� ������ ������ �ڵ尡 ��Ȳ�մϴ�. ���ۿ��� ������ ������, [Resharper](https://www.jetbrains.com/ko-kr/resharper/) ���� ���̳�, [Rider](https://www.jetbrains.com/ko-kr/rider/) ���� IDE���� �����ϴ� �ڵ� ���� ����� ����Ͽ� �ڵ带 �����ϰ� ������ �� �ֽ��ϴ�.
