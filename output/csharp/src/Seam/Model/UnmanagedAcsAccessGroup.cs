using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
[DataContract(Name = "seamModel_unmanagedAcsAccessGroup_model")]
public class UnmanagedAcsAccessGroup
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroup() { }

public UnmanagedAcsAccessGroup(UnmanagedAcsAccessGroup.AccessGroupTypeEnum? accessGroupType = default, string? accessGroupTypeDisplayName = default, UnmanagedAcsAccessGroupAccessSchedule? accessSchedule = default, string? acsAccessGroupId = default, string? acsSystemId = default, string? connectedAccountId = default, string? createdAt = default, string? displayName = default, List<UnmanagedAcsAccessGroupErrors>? errors = default, UnmanagedAcsAccessGroup.ExternalTypeEnum? externalType = default, string? externalTypeDisplayName = default, bool? isManaged = default, string? name = default, List<UnmanagedAcsAccessGroupPendingMutations>? pendingMutations = default, List<UnmanagedAcsAccessGroupWarnings>? warnings = default, string? workspaceId = default)
{
AccessGroupType = accessGroupType;
AccessGroupTypeDisplayName = accessGroupTypeDisplayName;
AccessSchedule = accessSchedule;
AcsAccessGroupId = acsAccessGroupId;
AcsSystemId = acsSystemId;
ConnectedAccountId = connectedAccountId;
CreatedAt = createdAt;
DisplayName = displayName;
Errors = errors;
ExternalType = externalType;
ExternalTypeDisplayName = externalTypeDisplayName;
IsManaged = isManaged;
Name = name;
PendingMutations = pendingMutations;
Warnings = warnings;
WorkspaceId = workspaceId;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum AccessGroupTypeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "pti_unit")]
PtiUnit = 1,

[EnumMember(Value = "pti_access_level")]
PtiAccessLevel = 2,

[EnumMember(Value = "salto_ks_access_group")]
SaltoKsAccessGroup = 3,

[EnumMember(Value = "brivo_group")]
BrivoGroup = 4,

[EnumMember(Value = "salto_space_group")]
SaltoSpaceGroup = 5,

[EnumMember(Value = "dormakaba_community_access_group")]
DormakabaCommunityAccessGroup = 6,

[EnumMember(Value = "dormakaba_ambiance_access_group")]
DormakabaAmbianceAccessGroup = 7,

[EnumMember(Value = "avigilon_alta_group")]
AvigilonAltaGroup = 8,

[EnumMember(Value = "kisi_access_group")]
KisiAccessGroup = 9,
}

[JsonConverter(typeof(JsonSubtypes), "error_code")]
[JsonSubtypes.FallBackSubType(typeof(UnmanagedAcsAccessGroupErrorsUnrecognized))]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupErrorsFailedToCreateOnAcsSystem), "failed_to_create_on_acs_system")]
public abstract class UnmanagedAcsAccessGroupErrors
{
public abstract string ErrorCode { get; }

public abstract override string ToString();
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupErrorsFailedToCreateOnAcsSystem_model")]
public class UnmanagedAcsAccessGroupErrorsFailedToCreateOnAcsSystem : UnmanagedAcsAccessGroupErrors
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupErrorsFailedToCreateOnAcsSystem() { }

public UnmanagedAcsAccessGroupErrorsFailedToCreateOnAcsSystem(string? createdAt = default, string errorCode = default, string? message = default)
{
CreatedAt = createdAt;
ErrorCode = errorCode;
Message = message;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
public override string ErrorCode { get; } = "failed_to_create_on_acs_system";

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupErrorsUnrecognized_model")]
public class UnmanagedAcsAccessGroupErrorsUnrecognized : UnmanagedAcsAccessGroupErrors
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupErrorsUnrecognized() { }

public UnmanagedAcsAccessGroupErrorsUnrecognized(string errorCode = default)
{
ErrorCode = errorCode;
}

[DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
public override string ErrorCode { get; } = "unrecognized";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum ExternalTypeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "pti_unit")]
PtiUnit = 1,

[EnumMember(Value = "pti_access_level")]
PtiAccessLevel = 2,

[EnumMember(Value = "salto_ks_access_group")]
SaltoKsAccessGroup = 3,

[EnumMember(Value = "brivo_group")]
BrivoGroup = 4,

[EnumMember(Value = "salto_space_group")]
SaltoSpaceGroup = 5,

[EnumMember(Value = "dormakaba_community_access_group")]
DormakabaCommunityAccessGroup = 6,

[EnumMember(Value = "dormakaba_ambiance_access_group")]
DormakabaAmbianceAccessGroup = 7,

[EnumMember(Value = "avigilon_alta_group")]
AvigilonAltaGroup = 8,

[EnumMember(Value = "kisi_access_group")]
KisiAccessGroup = 9,
}

[JsonConverter(typeof(JsonSubtypes), "mutation_code")]
[JsonSubtypes.FallBackSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsUnrecognized))]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate), "deferring_user_membership_update")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembership), "updating_entrance_membership")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembership), "updating_user_membership")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessSchedule), "updating_access_schedule")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformation), "updating_group_information")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsDeferringDeletion), "deferring_deletion")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsDeleting), "deleting")]
[JsonSubtypes.KnownSubType(typeof(UnmanagedAcsAccessGroupPendingMutationsCreating), "creating")]
public abstract class UnmanagedAcsAccessGroupPendingMutations
{
public abstract string MutationCode { get; }

public abstract override string ToString();
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsCreating_model")]
public class UnmanagedAcsAccessGroupPendingMutationsCreating : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsCreating() { }

public UnmanagedAcsAccessGroupPendingMutationsCreating(string? createdAt = default, string? message = default, string mutationCode = default)
{
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "creating";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsDeleting_model")]
public class UnmanagedAcsAccessGroupPendingMutationsDeleting : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsDeleting() { }

public UnmanagedAcsAccessGroupPendingMutationsDeleting(string? createdAt = default, string? message = default, string mutationCode = default)
{
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "deleting";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsDeferringDeletion_model")]
public class UnmanagedAcsAccessGroupPendingMutationsDeferringDeletion : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsDeferringDeletion() { }

public UnmanagedAcsAccessGroupPendingMutationsDeferringDeletion(string? createdAt = default, string? message = default, string mutationCode = default)
{
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "deferring_deletion";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformation_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformation : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformation() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformation(string? createdAt = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationFrom? from = default, string? message = default, string mutationCode = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_group_information";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationFrom_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationFrom
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationFrom() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationFrom(string? name = default)
{
Name = name;
}

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationTo_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationTo
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationTo() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingGroupInformationTo(string? name = default)
{
Name = name;
}

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingAccessSchedule_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessSchedule : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessSchedule() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessSchedule(string? createdAt = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom? from = default, string? message = default, string mutationCode = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_access_schedule";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom(string? endsAt = default, string? startsAt = default)
{
EndsAt = endsAt;
StartsAt = startsAt;
}

[DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
public string? EndsAt { get; set; }

[DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
public string? StartsAt { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleTo_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleTo
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleTo() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingAccessScheduleTo(string? endsAt = default, string? startsAt = default)
{
EndsAt = endsAt;
StartsAt = startsAt;
}

[DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
public string? EndsAt { get; set; }

[DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
public string? StartsAt { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingUserMembership_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembership : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembership() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembership(string? createdAt = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipFrom? from = default, string? message = default, string mutationCode = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_user_membership";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipFrom_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipFrom
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipFrom() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipFrom(string? acsUserId = default)
{
AcsUserId = acsUserId;
}

[DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsUserId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipTo_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipTo
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipTo() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingUserMembershipTo(string? acsUserId = default)
{
AcsUserId = acsUserId;
}

[DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsUserId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembership_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembership : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembership() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembership(string? createdAt = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom? from = default, string? message = default, string mutationCode = default, UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_entrance_membership";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom(string? acsEntranceId = default)
{
AcsEntranceId = acsEntranceId;
}

[DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsEntranceId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo() { }

public UnmanagedAcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo(string? acsEntranceId = default)
{
AcsEntranceId = acsEntranceId;
}

[DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsEntranceId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate_model")]
public class UnmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate() { }

public UnmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate(string? acsUserId = default, string? createdAt = default, string? message = default, string mutationCode = default, UnmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate.VariantEnum? variant = default)
{
AcsUserId = acsUserId;
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
Variant = variant;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum VariantEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "adding")]
Adding = 1,

[EnumMember(Value = "removing")]
Removing = 2,
}

[DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsUserId { get; set; }

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "deferring_user_membership_update";

[DataMember(Name = "variant", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupPendingMutationsDeferringUserMembershipUpdate.VariantEnum? Variant { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupPendingMutationsUnrecognized_model")]
public class UnmanagedAcsAccessGroupPendingMutationsUnrecognized : UnmanagedAcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupPendingMutationsUnrecognized() { }

public UnmanagedAcsAccessGroupPendingMutationsUnrecognized(string mutationCode = default)
{
MutationCode = mutationCode;
}

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "unrecognized";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataMember(Name = "access_group_type", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroup.AccessGroupTypeEnum? AccessGroupType { get; set; }

[DataMember(Name = "access_group_type_display_name", IsRequired = false, EmitDefaultValue = false)]
public string? AccessGroupTypeDisplayName { get; set; }

[DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupAccessSchedule? AccessSchedule { get; set; }

[DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsAccessGroupId { get; set; }

[DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsSystemId { get; set; }

[DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
public string? ConnectedAccountId { get; set; }

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
public string? DisplayName { get; set; }

[DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
public List<UnmanagedAcsAccessGroupErrors>? Errors { get; set; }

[DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroup.ExternalTypeEnum? ExternalType { get; set; }

[DataMember(Name = "external_type_display_name", IsRequired = false, EmitDefaultValue = false)]
public string? ExternalTypeDisplayName { get; set; }

[DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
public bool? IsManaged { get; set; }

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

[DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
public List<UnmanagedAcsAccessGroupPendingMutations>? PendingMutations { get; set; }

[DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
public List<UnmanagedAcsAccessGroupWarnings>? Warnings { get; set; }

[DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
public string? WorkspaceId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupAccessSchedule_model")]
public class UnmanagedAcsAccessGroupAccessSchedule
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupAccessSchedule() { }

public UnmanagedAcsAccessGroupAccessSchedule(string? endsAt = default, string? startsAt = default)
{
EndsAt = endsAt;
StartsAt = startsAt;
}

[DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
public string? EndsAt { get; set; }

[DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
public string? StartsAt { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_unmanagedAcsAccessGroupWarnings_model")]
public class UnmanagedAcsAccessGroupWarnings
{
[JsonConstructorAttribute]
protected UnmanagedAcsAccessGroupWarnings() { }

public UnmanagedAcsAccessGroupWarnings(string? createdAt = default, string? message = default, UnmanagedAcsAccessGroupWarnings.WarningCodeEnum? warningCode = default)
{
CreatedAt = createdAt;
Message = message;
WarningCode = warningCode;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum WarningCodeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "unknown_issue_with_acs_access_group")]
UnknownIssueWithAcsAccessGroup = 1,

[EnumMember(Value = "being_deleted")]
BeingDeleted = 2,
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
public UnmanagedAcsAccessGroupWarnings.WarningCodeEnum? WarningCode { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

}
